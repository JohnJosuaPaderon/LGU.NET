using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers
{
    public sealed class HumanResourceManager : SqlManagerBase, IHumanResourceManager
    {
        public HumanResourceManager(
            IConnectionStringSource connectionStringSource,
            IPayrollManager<SqlConnection, SqlTransaction> payrollManager,
            IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction> payrollContractualEmployeeManager) : base(connectionStringSource, "HumanResource")
        {
            _PayrollManager = payrollManager;
            _PayrollContractualEmployeeManager = payrollContractualEmployeeManager;
        }

        private IPayrollManager<SqlConnection, SqlTransaction> _PayrollManager;
        private IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction> _PayrollContractualEmployeeManager;

        public IProcessResult<IContractualPayrollCluster> InsertPayroll(IContractualPayrollCluster payrollCluster)
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

                            var payrollResult = _PayrollManager.Insert(payrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < payrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = _PayrollContractualEmployeeManager.Insert(payrollCluster.Employees[i], connection, transaction);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        payrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(payrollCluster, status, message);
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

        public async Task<IProcessResult<IContractualPayrollCluster>> InsertPayrollAsync(IContractualPayrollCluster payrollCluster)
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

                            var payrollResult = await _PayrollManager.InsertAsync(payrollCluster.Payroll, connection, transaction);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < payrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = await _PayrollContractualEmployeeManager.InsertAsync(payrollCluster.Employees[i], connection, transaction);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        payrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(payrollCluster, status, message);
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

        public async Task<IProcessResult<IContractualPayrollCluster>> InsertPayrollAsync(IContractualPayrollCluster payrollCluster, CancellationToken cancellationToken)
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

                            var payrollResult = await _PayrollManager.InsertAsync(payrollCluster.Payroll, connection, transaction, cancellationToken);

                            if (payrollResult.Status == ProcessResultStatus.Success)
                            {
                                for (int i = 0; i < payrollCluster.Employees.Count; i++)
                                {
                                    var employeeResult = await _PayrollContractualEmployeeManager.InsertAsync(payrollCluster.Employees[i], connection, transaction, cancellationToken);

                                    if (employeeResult.Status != ProcessResultStatus.Success)
                                    {
                                        transaction.Rollback();
                                        status = employeeResult.Status;
                                        message = employeeResult.Message;
                                        break;
                                    }
                                    else
                                    {
                                        payrollCluster.Employees[i] = employeeResult.Data;
                                    }
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                status = payrollResult.Status;
                                message = payrollResult.Message;
                            }

                            return new ProcessResult<IContractualPayrollCluster>(payrollCluster, status, message);
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
