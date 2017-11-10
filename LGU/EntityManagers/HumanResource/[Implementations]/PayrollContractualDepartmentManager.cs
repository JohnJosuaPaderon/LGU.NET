using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollContractualDepartmentManager : EntityManagerBase<IPayrollContractualDepartment, long>, IPayrollContractualDepartmentManager
    {
        private const string MESSAGE_INVALID = "Invalid Payroll Contractual Department.";

        public PayrollContractualDepartmentManager(
            IGeneratePayrollContractualDepartmentList generateList,
            IInsertPayrollContractualDepartment insert)
        {
            _GenerateList = generateList;
            _Insert = insert;

            _InvalidResult = new ProcessResult<IPayrollContractualDepartment>(ProcessResultStatus.Failed, MESSAGE_INVALID);
        }

        private readonly IGeneratePayrollContractualDepartmentList _GenerateList;
        private readonly IInsertPayrollContractualDepartment _Insert;
        private readonly IProcessResult<IPayrollContractualDepartment> _InvalidResult;

        public IEnumerableProcessResult<IPayrollContractualDepartment> GenerateList(ValueRange<DateTime> cutOff)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.Execute();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> GenerateListAsync(ValueRange<DateTime> cutOff)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> GenerateListAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            _GenerateList.CutOff = cutOff;
            return _GenerateList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IPayrollContractualDepartment> Insert(IPayrollContractualDepartment payrollContractualDepartment, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualDepartment != null)
            {
                _Insert.PayrollContractualDepartment = payrollContractualDepartment;
                return AddUpdateIfSuccess(_Insert.Execute(connection, transaction));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> InsertAsync(IPayrollContractualDepartment payrollContractualDepartment, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualDepartment != null)
            {
                _Insert.PayrollContractualDepartment = payrollContractualDepartment;
                return AddUpdateIfSuccess(await _Insert.ExecuteAsync(connection, transaction));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> InsertAsync(IPayrollContractualDepartment payrollContractualDepartment, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (payrollContractualDepartment != null)
            {
                _Insert.PayrollContractualDepartment = payrollContractualDepartment;
                return AddUpdateIfSuccess(await _Insert.ExecuteAsync(connection, transaction));
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
