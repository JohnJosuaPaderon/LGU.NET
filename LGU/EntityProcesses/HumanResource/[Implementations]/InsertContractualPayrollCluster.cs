using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertContractualPayrollCluster : HumanResourceProcessBaseV2, IInsertContractualPayrollCluster
    {
        public InsertContractualPayrollCluster(
            IConnectionStringSource connectionStringSource,
            IPayrollManager<SqlConnection, SqlTransaction> payrollManager,
            IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction> payrollContractualEmployeeManager) : base(connectionStringSource)
        {
            _PayrollManager = payrollManager;
            _PayrollContractualEmployeeManager = payrollContractualEmployeeManager;
        }

        private readonly IPayrollManager<SqlConnection, SqlTransaction> _PayrollManager;
        private readonly IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction> _PayrollContractualEmployeeManager;

        public IContractualPayrollCluster PayrollCluster { get; set; }

        private IProcessResult<IContractualPayrollCluster> RollbackTransaction(SqlTransaction transaction, IProcessResult baseResult)
        {
            transaction.Rollback();
            return new ProcessResult<IContractualPayrollCluster>(baseResult.Status, baseResult.Message);
        }

        private IProcessResult<IContractualPayrollCluster> RollbackTransaction(SqlTransaction transaction, Exception exception)
        {
            transaction.Rollback();
            return new ProcessResult<IContractualPayrollCluster>(exception);
        }

        private IProcessResult<IContractualPayrollCluster> CommitTransaction(SqlTransaction transaction)
        {
            transaction.Commit();
            return new ProcessResult<IContractualPayrollCluster>(PayrollCluster);
        }

        public IProcessResult<IContractualPayrollCluster> Execute()
        {
            try
            {
                using (var connection = _ConnectionEstablisher.Establish())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var payrollResult = _PayrollManager.Insert(PayrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                
                            }
                            else
                            {
                                return RollbackTransaction(transaction, payrollResult);
                            }

                            return CommitTransaction(transaction);
                        }
                        catch (Exception ex)
                        {
                            return RollbackTransaction(transaction, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<IContractualPayrollCluster>(ex);
            }
        }

        public async Task<IProcessResult<IContractualPayrollCluster>> ExecuteAsync()
        {
            try
            {
                using (var connection = await _ConnectionEstablisher.EstablishAsync())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var payrollResult = await _PayrollManager.InsertAsync(PayrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                
                            }
                            else
                            {
                                RollbackTransaction(transaction, payrollResult);
                            }

                            return CommitTransaction(transaction);
                        }
                        catch (Exception ex)
                        {
                            return RollbackTransaction(transaction, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<IContractualPayrollCluster>(ex);
            }
        }

        public async Task<IProcessResult<IContractualPayrollCluster>> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var payrollResult = await _PayrollManager.InsertAsync(PayrollCluster.Payroll, connection, transaction, cancellationToken);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                
                            }
                            else
                            {
                                return RollbackTransaction(transaction, payrollResult);
                            }

                            return CommitTransaction(transaction);
                        }
                        catch (Exception ex)
                        {
                            return RollbackTransaction(transaction, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<IContractualPayrollCluster>(ex);
            }
        }
    }
}
