﻿namespace LGU.Entities.HumanResource
{
    public interface IContractualPayrollCluster : IPayrollCluster<IPayrollContractualEmployee>
    {
        IContractualPayrollClusterInclusion Inclusion { get; set; }
    }
}
