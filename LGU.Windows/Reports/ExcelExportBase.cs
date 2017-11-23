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
        protected Excel.Worksheet ActiveWorksheet { get; private set; }
        protected Excel.Worksheet TemplateWorksheet { get; private set; }
        protected Excel.Range CurrentRange { get; set; }
        protected bool Faulted { get; set; }

        protected virtual void Initialize()
        {
            try
            {
                Application = new Excel.Application()
                {
                    DisplayAlerts = false
                };
                Workbooks = Application.Workbooks;
            }
            catch (Exception ex)
            {
                Faulted = true;
                EventHandler.OnException(ex);
            }
        }

        protected void OpenTemplate(string templatePath, int templateSheetIndex = 1)
        {
            if (Application != null)
            {
                if (File.Exists(templatePath))
                {
                    Workbook = Workbooks.Open(templatePath);
                    Sheets = Workbook.Sheets;
                    TemplateWorksheet = Sheets[templateSheetIndex];
                }
                else
                {
                    Faulted = true;
                    EventHandler?.OnError($"Template not found: '{templatePath}'");
                }
            }
            else
            {
                Faulted = true;
                EventHandler?.OnError("Microsoft Office Excel is not running.");
            }
        }

        protected void SetActiveWorksheet(int worksheetIndex, string name = null)
        {
            if (worksheetIndex <= 0)
            {
                Faulted = true;
                EventHandler?.OnError("Worksheet index cannot be zero or any negative integer.");
            }
            else
            {
                if (Sheets == null)
                {
                    Faulted = true;
                    EventHandler?.OnError("Workbook has no sheet.");
                }
                else if (Sheets.Count < worksheetIndex)
                {
                    Faulted = true;
                    EventHandler?.OnError("Worksheet index is out of range.");
                }
                else
                {
                    ActiveWorksheet = Sheets[worksheetIndex];

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        ActiveWorksheet.Name = name;
                    }
                }
            }
        }

        protected Excel.Worksheet DuplicateWorksheet(Excel.Worksheet templateWorksheet, string name, bool setAsActive = true)
        {
            var sheet = templateWorksheet.Copy(After: Sheets[Sheets.Count]);
            sheet.Name = name;

            if (setAsActive)
            {
                ActiveWorksheet = sheet;
            }

            return sheet;
        }

        protected Excel.Worksheet DuplicateTemplate(string name, bool setAsActive = true)
        {
            if (TemplateWorksheet != null)
            {
                TemplateWorksheet.Copy(After: Sheets[Sheets.Count]);
                var sheet = Sheets[Sheets.Count];
                sheet.Name = name;

                if (setAsActive)
                {
                    ActiveWorksheet = sheet;
                }

                return sheet;
            }
            else
            {
                Faulted = true;
                EventHandler?.OnError("Template worksheet is null.");
                return null;
            }
        }

        protected bool IsNullOrWhiteSpace(Excel.Range range)
        {
            return string.IsNullOrWhiteSpace(range.Value?.ToString()) || string.IsNullOrWhiteSpace(range.Value2?.ToString());
        }

        protected void SetCellValue(int row, int column, object value)
        {
            CurrentRange = ActiveWorksheet.Cells[row, column];
            CurrentRange.Value = value;
        }

        protected void SetCellValueIfNotDefault<T>(int row, int column, T value)
        {
            if (!Equals(value, default(T)))
            {
                SetCellValue(row, column, value);
            }
        }

        protected void SetCellValueIfNotDefault<T>(int row, int column, T value, T defaultValue)
        {
            if (!Equals(value, defaultValue))
            {
                SetCellValue(row, column, value);
            }
        }

        protected void SetCellValue(ExcelCell cell, object value)
        {
            SetCellValue(cell.RowIndex, cell.ColumnIndex, value);
        }

        protected void SetCellValueIfNotDefault<T>(ExcelCell cell, T value)
        {
            if (!Equals(value, default(T)))
            {
                SetCellValue(cell, value);
            }
        }

        protected void SetCellValueIfNotDefault<T>(ExcelCell cell, T value, T defaultValue)
        {
            if (!Equals(value, defaultValue))
            {
                SetCellValue(cell, value);
            }
        }

        protected void SetCellValue(int row, int column, object value, string numberFormat)
        {
            CurrentRange = ActiveWorksheet.Cells[row, column];
            CurrentRange.NumberFormat = numberFormat;
            CurrentRange.Value = value;
        }

        protected void SetCellValueIfNotDefault<T>(int row, int column, T value, string numberFormat)
        {
            if (!Equals(value, default(T)))
            {
                SetCellValue(row, column, value, numberFormat);
            }
        }

        protected void SetCellValueIfNotDefault<T>(int row, int column, T value, T defaultValue, string numberFormat)
        {
            if (!Equals(value, defaultValue))
            {
                SetCellValue(row, column, value, numberFormat);
            }
        }

        protected Excel.Range GetRange(ExcelCell beginCell, ExcelCell endCell)
        {
            return GetRange(beginCell, endCell, ActiveWorksheet);
        }

        protected Excel.Range GetRange(ExcelCell beginCell, ExcelCell endCell, Excel.Worksheet worksheet)
        {
            return worksheet.Range[GetCell(beginCell, worksheet), GetCell(endCell, worksheet)];
        }

        protected Excel.Range GetCell(ExcelCell excelCell)
        {
            return GetCell(excelCell, ActiveWorksheet);
        }

        protected Excel.Range GetCell(ExcelCell excelCell, Excel.Worksheet worksheet)
        {
            return worksheet.Cells[excelCell.RowIndex, excelCell.ColumnIndex];
        }

        public virtual void Dispose()
        {
            if (ActiveWorksheet != null)
            {
                Marshal.ReleaseComObject(ActiveWorksheet);
                ActiveWorksheet = null;
            }

            if (TemplateWorksheet != null)
            {
                Marshal.ReleaseComObject(TemplateWorksheet);
                TemplateWorksheet = null;
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
