using LGU.Entities.HumanResource;
using LGU.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportLocator : WordExportBase, IExportLocator
    {
        public ExportLocator(ILocatorReportInfoProvider infoProvider)
        {
            r_InfoProvider = infoProvider;
        }

        private readonly ILocatorReportInfoProvider r_InfoProvider;

        public Locator Locator { get; set; }

        public void Export()
        {
            Initialize();
            OpenTemplate(r_InfoProvider.Template);

            foreach (Word.Field field in Document.Fields)
            {
                var FIELD_NAME = field.Result.Text?.TrimStart('«')?.TrimEnd('»');

                switch (FIELD_NAME)
                {
                    case "DATE":
                        field.Result.Text = Locator.Date.ToString("MMM d, yyyy");
                        break;
                    case "LEAVE_TYPE":
                        field.Result.Text = Locator.LeaveType?.Description;
                        break;
                    case "PURPOSE":
                        field.Result.Text = Locator.Purpose;
                        break;
                    case "OFFICE_OUT_TIME":
                        field.Result.Text = Locator.OfficeOutTime.ToString("MMM d, yyyy hh:mm tt");
                        break;
                    case "EXPECTED_RETURN_TIME":
                        field.Result.Text = Locator.ExpectedReturnTime?.ToString("MMM d, yyyy hh:mm tt");
                        break;
                    case "REQUESTOR":
                        field.Result.Text = Locator.Requestor?.FullName;
                        break;
                    case "DEPARTMENT_HEAD":
                        if (string.IsNullOrWhiteSpace(Locator.DepartmentHead))
                        {
                            field.Result.Text = Locator.Requestor?.Department?.Head?.InformalFullName;
                        }
                        else
                        {
                            field.Result.Text = Locator.DepartmentHead;
                        }
                        break;
                    case "DEPARTMENT_HEAD_TITLE":
                        if (string.IsNullOrWhiteSpace(Locator.DepartmentHead))
                        {
                            field.Result.Text = Locator.Requestor?.Department?.Head?.Title;
                        }
                        else
                        {
                            field.Result.Text = "DEPARTMENT HEAD";
                        }
                        break;
                    default:
                        break;
                }
            }

            string fileName = $"{Locator.Requestor?.Id}-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.docx";
            DirectoryResolver.Resolve(r_InfoProvider.SaveDirectory);
            Print();
            //SaveAs(Path.Combine(r_InfoProvider.SaveDirectory, fileName));
        }

        public Task ExportAsync()
        {
            return Task.Run(() => Export());
        }
    }
}
