using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Spreadsheet.ExcelCharactersDecoratorCommands
{
    public struct FontItalicCommand : IExcelCharactersDecoratorCommand
    {
        public static FontItalicCommand Apply()
        {
            return new FontItalicCommand();
        }

        public void Apply(Excel.Characters excelCharacters)
        {
            var font = excelCharacters.Font;
            font.Italic = true;
        }
    }
}
