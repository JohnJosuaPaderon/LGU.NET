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
        public ExportLocator(IHumanResourcePathProvider pathProvider)
        {
            r_PathProvider = pathProvider;
        }

        private readonly IHumanResourcePathProvider r_PathProvider;

        public Locator Locator { get; set; }

        public void Export()
        {
            Initialize();
            OpenTemplate(r_PathProvider.LocatorTemplate);

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
                        field.Result.Text = Locator.Requestor?.Department?.Head?.InformalFullName;
                        break;
                    case "DEPARTMENT_HEAD_TITLE":
                        field.Result.Text = Locator.Requestor?.Department?.Head?.Title;
                        break;
                    default:
                        break;
                }
            }

            string fileName = $"{Locator.Requestor?.Id}-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.docx";
            DirectoryResolver.Resolve(r_PathProvider.LocatorSaveDirectory);
            SaveAs(Path.Combine(r_PathProvider.LocatorSaveDirectory, fileName));
        }

        public Task ExportAsync()
        {
            return Task.Run(() => Export());
        }
    }
}
