using LGU.Configurations;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IPayrollConfigurationProvider
    {
        string MayorId { get; }
        string HumanResourceHeadId { get; }
        string TreasurerId { get; }
        string CityAccountantId { get; }
        string CityBudgetOfficerId { get; }
        IJConfigurationHeader Header { get; }
    }
}
