using System;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Reports
{
    public abstract class ExcelExportBase : IDisposable
    {
        public IExportEventHandler EventHandler { get; set; }
        protected Excel.Application Application { get; private set; }
        protected Excel.Workbooks Workbooks { get; private set; }
        protected Excel.Workbook Workbook { get; private set; }
        protected Excel.Sheets Sheets { get; private set; }
        protected Excel.Worksheet Worksheet { get; private set; }
        private Excel.Range CurrentRange { get; set; }

        protected void Initialize()
        {
            Application = new Excel.Application()
            {
                DisplayAlerts = false
            };
        }

        protected void OpenTemplate(string templatePath)
        {
            if (Application != null)
            {
                if (File.Exists(templatePath))
                {
                    Workbooks = Application.Workbooks;
                    Workbook = Workbooks.Open(templatePath);
                    Sheets = Workbook.Sheets;
                }
                else
                {
                    EventHandler?.OnError($"Template not found: '{templatePath}'");
                }
            }
            else
            {
                EventHandler?.OnError("Microsoft Office Excel is not running.");
            }
        }

        protected void SetActiveWorksheet(int worksheetIndex, string name = null)
        {
            if (worksheetIndex <= 0)
            {
                EventHandler?.OnError("Worksheet index cannot be zero or any negative integer.");
            }
            else
            {
                if (Sheets == null)
                {
                    EventHandler?.OnError("Workbook has no sheet.");
                }
                else if (Sheets.Count < worksheetIndex)
                {

                    EventHandler?.OnError("Worksheet index is out of range.");
                }
                else
                {
                    Worksheet = Sheets[worksheetIndex];

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Worksheet.Name = name;
                    }
                }
            }
        }

        protected void DuplicateTemplateWorksheet(Excel.Worksheet templateWorksheet, string name)
        {
            Worksheet = templateWorksheet.Copy(After: Sheets[Sheets.Count]);
            Worksheet.Name = name;
        }

        protected void SetCellValue(int row, int column, object value)
        {
            SetCellValue(row, column, value, string.Empty);
        }

        protected void SetCellValue(ExcelCell cell, object value)
        {
            SetCellValue(cell.RowIndex, cell.ColumnIndex, value);
        }

        protected void SetCellValue(int row, int column, object value, string numberFormat)
        {
            CurrentRange = Worksheet.Cells[row, column];
            CurrentRange.NumberFormat = numberFormat;
            CurrentRange.Value = value;
        }

        public virtual void Dispose()
        {
            if (Worksheet != null)
            {
                Marshal.ReleaseComObject(Worksheet);
                Worksheet = null;
            }

            if (Sheets != null)
            {
                Marshal.ReleaseComObject(Sheets);
                Sheets = null;
            }

            if (Workbook != null)
            {
                Workbook.Close();
                Marshal.ReleaseComObject(Workbook);
                Workbook = null;
            }

            if (Workbooks != null)
            {
                foreach (Excel.Workbook book in Workbooks)
                {
                    book.Close();
                    Marshal.ReleaseComObject(book);
                }

                Marshal.ReleaseComObject(Workbooks);
                Workbooks = null;
            }

            if (Application != null)
            {
                Application.Quit();
                Marshal.ReleaseComObject(Application);
                Application = null;
            }
        }
    }
}
