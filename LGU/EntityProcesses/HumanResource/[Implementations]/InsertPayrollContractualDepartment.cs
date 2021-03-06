﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPayrollContractualDepartment : HumanResourceProcessBaseV2, IInsertPayrollContractualDepartment
    {
        private readonly string MESSAGE_FAILED = "Failed to insert Payroll Contractual Department.";

        public InsertPayrollContractualDepartment(IConnectionStringSource connectionStringSource, IPayrollContractualDepartmentParameters parameters, IPayrollContractualEmployeeManager employeeManager) : base(connectionStringSource)
        {
            _Parameters = parameters;
            _EmployeeManager = employeeManager;
        }

        private readonly IPayrollContractualDepartmentParameters _Parameters;
        private readonly IPayrollContractualEmployeeManager _EmployeeManager;

        public IPayrollContractualDepartment PayrollContractualDepartment { get; set; }

        private SqlQueryInfo<IPayrollContractualDepartment> QueryInfo =>
            SqlQueryInfo<IPayrollContractualDepartment>.CreateProcedureQueryInfo(PayrollContractualDepartment, GetQualifiedDbObjectName(), GetProcessResult)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.PayrollId, PayrollContractualDepartment.Payroll?.Id)
            .AddInputParameter(_Parameters.DepartmentId, PayrollContractualDepartment.Department?.Id)
            .AddInputParameter(_Parameters.HeadId, PayrollContractualDepartment.Head?.Id)
            .AddInputParameter(_Parameters.Ordinal, PayrollContractualDepartment.Ordinal)
            .AddLogByParameter();

        private IProcessResult<IPayrollContractualDepartment> GetProcessResult(IPayrollContractualDepartment data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
                return new ProcessResult<IPayrollContractualDepartment>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IPayrollContractualDepartment>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        private IProcessResult<IPayrollContractualDepartment> FailedResult_Employee(IProcessResult<IPayrollContractualEmployee> employeeResult)
        {
            return new ProcessResult<IPayrollContractualDepartment>($"{MESSAGE_FAILED} {employeeResult.Message}", employeeResult.Exception);
        }

        public IProcessResult<IPayrollContractualDepartment> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            var result = _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);

            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var employee in result.Data.Employees)
                {
                    var employeeResult = _EmployeeManager.Insert(employee, connection, transaction);

                    if (employeeResult.Status == ProcessResultStatus.Failed)
                    {
                        return FailedResult_Employee(employeeResult);
                    }
                }
            }

            return result;
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            var result = await _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);

            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var employee in result.Data.Employees)
                {
                    var employeeResult = await _EmployeeManager.InsertAsync(employee, connection, transaction);

                    if (employeeResult.Status == ProcessResultStatus.Failed)
                    {
                        return FailedResult_Employee(employeeResult);
                    }
                }
            }

            return result;
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var result = await _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);

            if (result.Status == ProcessResultStatus.Success)
            {
                foreach (var employee in result.Data.Employees)
                {
                    var employeeResult = await _EmployeeManager.InsertAsync(employee, connection, transaction, cancellationToken);

                    if (employeeResult.Status == ProcessResultStatus.Failed)
                    {
                        return FailedResult_Employee(employeeResult);
                    }
                }
            }

            return result;
        }
    }
}
