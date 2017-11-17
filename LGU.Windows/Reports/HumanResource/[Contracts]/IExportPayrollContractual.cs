using LGU.Entities.HumanResource;

namespace LGU.Reports.HumanResource
{
    public interface IExportPayrollContractual : IExport
    {
        IPayrollContractual PayrollContractual { get; set; }
    }
}
