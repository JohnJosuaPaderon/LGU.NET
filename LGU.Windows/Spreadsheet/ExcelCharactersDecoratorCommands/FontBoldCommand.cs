using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Spreadsheet.ExcelCharactersDecoratorCommands
{
    public struct FontBoldCommand : IExcelCharactersDecoratorCommand
    {
        public static FontBoldCommand Apply()
        {
            return new FontBoldCommand();
        }

        public void Apply(Excel.Characters excelCharacters)
        {
            var font = excelCharacters.Font;
            font.Bold = true;
        }
    }
}
