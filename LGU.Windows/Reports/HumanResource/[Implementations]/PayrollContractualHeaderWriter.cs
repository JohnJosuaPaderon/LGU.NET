using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Spreadsheet;
using LGU.Spreadsheet.ExcelCharactersDecoratorCommands;
using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Reports.HumanResource
{
    public sealed class PayrollContractualHeaderWriter : IPayrollContractualHeaderWriter
    {
        public PayrollContractualHeaderWriter(IExcelCharactersDecorator charactersDecorator)
        {
            _CharactersDecorator = charactersDecorator;
        }

        private const string PART_1 = "We hereby acknowledge to have received from ";
        private const string PART_2 = ", Treasurer of ";
        private const string PART_3 = ", the sums herein specified opposite our respective names, the same being full compensation for our services rendered during the period of ";
        private const string PART_4 = " to the correctness of which we hereby severally certify.";
        private const string NAVOTAS_CITY = "Navotas City";

        private readonly IExcelCharactersDecorator _CharactersDecorator;

        public IPayrollContractual PayrollContractual { get; set; }

        private string Treasurer { get; set; }
        private string CutOff { get; set; }

        private int TreasurerStartIndex
        {
            get { return PART_1.Length; }
        }

        private int NavotasCityStartIndex
        {
            get { return TreasurerStartIndex + Treasurer?.Length ?? 0 + PART_2.Length; }
        }

        private int CutOffStartIndex
        {
            get { return NavotasCityStartIndex + PART_3.Length; }
        }

        public void Write(Excel.Range excelRange)
        {
            if (PayrollContractual != null)
            {
                Treasurer = PayrollContractual.Treasurer?.InformalFullName;
                CutOff = PayrollContractual.RangeDate.ToFormattedString();

                excelRange.Value = string.Concat(PART_1, Treasurer, PART_2, NAVOTAS_CITY, PART_3, CutOff, PART_4);
                DecorateTreasurer(excelRange);
                DecorateNavotasCity(excelRange);
                DecorateCutOff(excelRange);
            }
        }

        private void DecorateTreasurer(Excel.Range excelRange)
        {
            var characters = excelRange.Characters[TreasurerStartIndex, Treasurer?.Length ?? 0];
            _CharactersDecorator.Decorate(characters, FontUnderlineCommand.Apply(), FontItalicCommand.Apply());
        }

        private void DecorateNavotasCity(Excel.Range excelRange)
        {
            var characters = excelRange.Characters[NavotasCityStartIndex, NAVOTAS_CITY.Length];
            _CharactersDecorator.Decorate(characters, FontItalicCommand.Apply(), FontUnderlineCommand.Apply());
        }

        private void DecorateCutOff(Excel.Range excelRange)
        {
            var characters = excelRange.Characters[CutOffStartIndex, CutOff.Length];
            _CharactersDecorator.Decorate(characters, FontItalicCommand.Apply(), FontUnderlineCommand.Apply());
        }
    }
}
