using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public interface IContractualPayrollSignatoryNotification : ICustomNotification
    {
        PayrollContractualModel Payroll { get; set; }
    }
}
