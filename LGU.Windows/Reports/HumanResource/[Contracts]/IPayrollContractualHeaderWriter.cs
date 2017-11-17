using LGU.Entities.HumanResource;
using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Reports.HumanResource
{
    public interface IPayrollContractualHeaderWriter
    {
        IPayrollContractual PayrollContractual { get; set; }
        void Write(Excel.Range excelRange);
    }
}
