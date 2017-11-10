using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPayrollContractual : HumanResourceProcessBaseV2, IInsertPayrollContractual
    {
        private const string MESSAGE_FAILED = "Failed to Insert Payroll Contractual";

        public InsertPayrollContractual(
            IConnectionStringSource connectionStringSource,
            IPayrollContractualParameters parameters,
            IPayrollContractualDepartmentManager departmentManager,
            IPayrollContractualInclusionManager inclusionManager) : base(connectionStringSource)
        {
            _Parameters = parameters;
            _DepartmentManager = departmentManager;
            _InclusionManager = inclusionManager;
        }

        private readonly IPayrollContractualParameters _Parameters;
        private readonly IPayrollContractualDepartmentManager _DepartmentManager;
        private readonly IPayrollContractualInclusionManager _InclusionManager;

        public IPayrollContractual PayrollContractual { get; set; }

        private SqlQueryInfo<IPayrollContractual> QueryInfo =>
            SqlQueryInfo<IPayrollContractual>.CreateProcedureQueryInfo(PayrollContractual, GetQualifiedDbObjectName(), GetProcessResult)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.CutOffId, PayrollContractual.CutOff?.Id)
            .AddInputParameter(_Parameters.RangeDateBegin, PayrollContractual.RangeDate.Begin)
            .AddInputParameter(_Parameters.RangeDateEnd, PayrollContractual.RangeDate.End)
            .AddInputParameter(_Parameters.RunDate, PayrollContractual.RunDate)
            .AddInputParameter(_Parameters.HumanResourceHeadId, PayrollContractual.HumanResourceHead?.Id)
            .AddInputParameter(_Parameters.MayorId, PayrollContractual.Mayor?.Id)
            .AddInputParameter(_Parameters.TreasurerId, PayrollContractual.Treasurer?.Id)
            .AddInputParameter(_Parameters.CityAccountantId, PayrollContractual.CityAccountant?.Id)
            .AddInputParameter(_Parameters.CityBudgetOfficerId, PayrollContractual.CityBudgetOfficer?.Id)
            .AddLogByParameter();

        private IProcessResult<IPayrollContractual> GetProcessResult(IPayrollContractual data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
                return new ProcessResult<IPayrollContractual>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IPayrollContractual>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        private IProcessResult<IPayrollContractual> FailedResult_FromInclusion(IProcessResult<IPayrollContractualInclusion> result)
        {
            return new ProcessResult<IPayrollContractual>(result.Message, result.Exception);
        }

        private IProcessResult<IPayrollContractual> FailedResult_FromDepartment(IProcessResult<IPayrollContractualDepartment> result)
        {
            return new ProcessResult<IPayrollContractual>(result.Message, result.Exception);
        }

        private IProcessResult<IPayrollContractual> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);
        }

        private Task<IProcessResult<IPayrollContractual>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);
        }

        private Task<IProcessResult<IPayrollContractual>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);
        }

        private IProcessResult<IPayrollContractual> InsertInclusion(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                var inclusionResult = _InclusionManager.Insert(result.Data.Inclusion, connection, transaction);

                if (inclusionResult.Status == ProcessResultStatus.Failed)
                {
                    result = FailedResult_FromInclusion(inclusionResult);
                }
            }

            return result;
        }

        private async Task<IProcessResult<IPayrollContractual>> InsertInclusionAsync(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                var inclusionResult = await _InclusionManager.InsertAsync(result.Data.Inclusion, connection, transaction);

                if (inclusionResult.Status == ProcessResultStatus.Failed)
                {
                    result = FailedResult_FromInclusion(inclusionResult);
                }
            }

            return result;
        }

        private async Task<IProcessResult<IPayrollContractual>> InsertInclusionAsync(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result, CancellationToken cancellationToken)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                var inclusionResult = await _InclusionManager.InsertAsync(result.Data.Inclusion, connection, transaction, cancellationToken);

                if (inclusionResult.Status == ProcessResultStatus.Failed)
                {
                    result = FailedResult_FromInclusion(inclusionResult);
                }
            }

            return result;
        }

        private IProcessResult<IPayrollContractual> InsertDepartments(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var department in result.Data.Departments)
                {
                    var departmentResult = _DepartmentManager.Insert(department, connection, transaction);

                    if (departmentResult.Status == ProcessResultStatus.Failed)
                    {
                        result = FailedResult_FromDepartment(departmentResult);
                        break;
                    }
                }
            }

            return result;
        }

        private async Task<IProcessResult<IPayrollContractual>> InsertDepartmentsAsync(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var department in result.Data.Departments)
                {
                    var departmentResult = await _DepartmentManager.InsertAsync(department, connection, transaction);

                    if (departmentResult.Status == ProcessResultStatus.Failed)
                    {
                        result = FailedResult_FromDepartment(departmentResult);
                        break;
                    }
                }
            }

            return result;
        }

        private async Task<IProcessResult<IPayrollContractual>> InsertDepartmentsAsync(SqlConnection connection, SqlTransaction transaction, IProcessResult<IPayrollContractual> result, CancellationToken cancellationToken)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var department in result.Data.Departments)
                {
                    var departmentResult = await _DepartmentManager.InsertAsync(department, connection, transaction, cancellationToken);

                    if (departmentResult.Status == ProcessResultStatus.Failed)
                    {
                        result = FailedResult_FromDepartment(departmentResult);
                        break;
                    }
                }
            }

            return result;
        }

        public IProcessResult<IPayrollContractual> Execute()
        {
            using (var connection = _ConnectionEstablisher.Establish())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = Execute(connection, transaction);

                        result = InsertInclusion(connection, transaction, result);
                        result = InsertDepartments(connection, transaction, result);

                        FinishTransaction(transaction, result);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new ProcessResult<IPayrollContractual>(ex);
                    }
                }
            }
        }

        public async Task<IProcessResult<IPayrollContractual>> ExecuteAsync()
        {
            using (var connection = await _ConnectionEstablisher.EstablishAsync())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await ExecuteAsync(connection, transaction);

                        result = await InsertInclusionAsync(connection, transaction, result);
                        result = await InsertDepartmentsAsync(connection, transaction, result);

                        FinishTransaction(transaction, result);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new ProcessResult<IPayrollContractual>(ex);
                    }
                }
            }
        }

        public async Task<IProcessResult<IPayrollContractual>> ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var connection = await _ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await ExecuteAsync(connection, transaction, cancellationToken);

                        result = await InsertInclusionAsync(connection, transaction, result, cancellationToken);
                        result = await InsertDepartmentsAsync(connection, transaction, result, cancellationToken);

                        FinishTransaction(transaction, result);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new ProcessResult<IPayrollContractual>(ex);
                    }
                }
            }
        }

        private static void FinishTransaction(SqlTransaction transaction, IProcessResult<IPayrollContractual> result)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
    }
}
