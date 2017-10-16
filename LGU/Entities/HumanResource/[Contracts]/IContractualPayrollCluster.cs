using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public interface IContractualPayrollCluster : IPayrollCluster<IPayrollContractualEmployee>
    {
        IContractualPayrollClusterInclusion Inclusion { get; set; }
        IEnumerable<IPayrollContractualDepartment> Departments { get; }
    }
}
