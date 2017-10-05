namespace LGU.Entities.HumanResource
{
    public class ContractualPayrollCluster : PayrollCluster<IPayrollContractualEmployee>, IContractualPayrollCluster
    {
        public IContractualPayrollClusterInclusion Inclusion { get; set; }
    }
}
