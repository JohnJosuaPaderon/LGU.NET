﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollManager<TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IProcessResult<IPayroll> Insert(IPayroll payroll);
        Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll);
        Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, CancellationToken cancellationToken);
        IProcessResult<IPayroll> Insert(IPayroll payroll, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
    }
}