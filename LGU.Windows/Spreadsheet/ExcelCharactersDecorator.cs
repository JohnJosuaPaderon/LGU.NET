using Excel = Microsoft.Office.Interop.Excel;
namespace LGU.Spreadsheet
{
    public sealed class ExcelCharactersDecorator : IExcelCharactersDecorator
    {
        public void Decorate(Excel.Characters excelCharacters, params IExcelCharactersDecoratorCommand[] commands)
        {
            foreach (var command in commands)
            {
                command.Apply(excelCharacters);
            }
        }
    }
}
