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
                            ProcessResultStatus status = ProcessResultStatus.Undefined;
                            string message = null;

                            var payrollResult = _PayrollManager.Insert(PayrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < PayrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = _PayrollContractualEmployeeManager.Insert(PayrollCluster.Employees[i], connection, transaction);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        PayrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(PayrollCluster, status, message);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return new ProcessResult<IContractualPayrollCluster>(ex);
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
                            ProcessResultStatus status = ProcessResultStatus.Undefined;
                            string message = null;

                            var payrollResult = await _PayrollManager.InsertAsync(PayrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < PayrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = await _PayrollContractualEmployeeManager.InsertAsync(PayrollCluster.Employees[i], connection, transaction);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        PayrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(PayrollCluster, status, message);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return new ProcessResult<IContractualPayrollCluster>(ex);
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
                            ProcessResultStatus status = ProcessResultStatus.Undefined;
                            string message = null;

                            var payrollResult = await _PayrollManager.InsertAsync(PayrollCluster.Payroll, connection, transaction, cancellationToken);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < PayrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = await _PayrollContractualEmployeeManager.InsertAsync(PayrollCluster.Employees[i], connection, transaction, cancellationToken);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        PayrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(PayrollCluster, status, message);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return new ProcessResult<IContractualPayrollCluster>(ex);
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
