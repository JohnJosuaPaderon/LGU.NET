using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollContractualDepartmentManager : IPayrollContractualDepartmentManager
    {
        public PayrollContractualDepartmentManager(IGeneratePayrollContractualDepartmentList generateList)
        {
            _GenerateList = generateList;
        }

        private readonly IGeneratePayrollContractualDepartmentList _GenerateList;

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
    }
}
