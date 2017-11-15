using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Spreadsheet
{
    public interface IExcelCharactersDecoratorCommand
    {
        void Apply(Excel.Characters excelCharacters);
    }
}
