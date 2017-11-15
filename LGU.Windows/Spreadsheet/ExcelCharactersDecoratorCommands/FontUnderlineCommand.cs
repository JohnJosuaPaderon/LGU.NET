using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Spreadsheet.ExcelCharactersDecoratorCommands
{
    public struct FontUnderlineCommand : IExcelCharactersDecoratorCommand
    {
        public static FontUnderlineCommand Apply()
        {
            return new FontUnderlineCommand();
        }

        public void Apply(Excel.Characters excelCharacters)
        {
            var font = excelCharacters.Font;
            font.Underline = true;
        }
    }
}
