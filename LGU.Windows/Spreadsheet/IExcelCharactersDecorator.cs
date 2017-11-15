using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Spreadsheet
{
    public interface IExcelCharactersDecorator
    {
        void Decorate(Excel.Characters excelCharacters, params IExcelCharactersDecoratorCommand[] commands);
    }
}
