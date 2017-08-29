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

        public ILocator Locator { get; set; }

        public void Export()
        {
            Initialize();
            OpenTemplate(r_InfoProvider.Template);

            string departmentHead = string.Empty;
            string departmentHeadTitle = string.Empty;

            if (!string.IsNullOrWhiteSpace(Locator.DepartmentHead))
            {
                departmentHead = Locator.DepartmentHead;
                departmentHeadTitle = "Department Head";
            }
            else if (Locator.Requestor?.DepartmentHead != null)
            {
                departmentHead = Locator.Requestor.DepartmentHead.InformalFullName;
                departmentHeadTitle = Locator.Requestor.DepartmentHead.Title;
            }
            else
            {
                departmentHead = Locator?.Requestor?.Department?.Head?.InformalFullName;
                departmentHeadTitle = Locator?.Requestor?.Department?.Head?.Title;
            }

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
                        field.Result.Text = departmentHead;
                        break;
                    case "DEPARTMENT_HEAD_TITLE":
                        field.Result.Text = departmentHeadTitle;
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
