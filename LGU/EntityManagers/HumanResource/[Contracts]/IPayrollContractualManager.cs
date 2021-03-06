﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualManager
    {
        IProcessResult<IPayrollContractual> GetById(long payrollContractualId);
        Task<IProcessResult<IPayrollContractual>> GetByIdAsync(long payrollContractualId);
        Task<IProcessResult<IPayrollContractual>> GetByIdAsync(long payrollContractualId, CancellationToken cancellationToken);
        IProcessResult<IPayrollContractual> Insert(IPayrollContractual payrollContractual);
        Task<IProcessResult<IPayrollContractual>> InsertAsync(IPayrollContractual payrollContractual);
        Task<IProcessResult<IPayrollContractual>> InsertAsync(IPayrollContractual payrollContractual, CancellationToken cancellationToken);
    }
}
