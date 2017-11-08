using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollContractualEmployeeManager : IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction>
    {
        private const string MESSAGE_INVALID = "Invalid payroll contractual employee.";

        public PayrollContractualEmployeeManager(
            IInsertPayrollContractualEmployee insert,
            IGeneratePayrollContractualEmployeeList generateList)
        {
            _Insert = insert;
            _GenerateList = generateList;

            _InvalidResult = new ProcessResult<IPayrollContractualEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID);
        }

        private readonly IInsertPayrollContractualEmployee _Insert;
        private readonly IGeneratePayrollContractualEmployeeList _GenerateList;
        private readonly IProcessResult<IPayrollContractualEmployee> _InvalidResult;

        public IEnumerableProcessResult<IPayrollContractualEmployee> GenerateList(ValueRange<DateTime> cutOff)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.Execute();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee payrollContractualEmployee)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return _Insert.Execute();
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return _Insert.Execute(connection, transaction);
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return await _Insert.ExecuteAsync();
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return await _Insert.ExecuteAsync(connection, transaction);
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, CancellationToken cancellationToken)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return await _Insert.ExecuteAsync(cancellationToken);
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (payrollContractualEmployee != null)
            {
                _Insert.PayrollContractualEmployee = payrollContractualEmployee;
                return await _Insert.ExecuteAsync(connection, transaction, cancellationToken);
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
