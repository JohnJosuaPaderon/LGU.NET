using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDefaultPayrollFromFile : IGetDefaultPayrollFromFile
    {
        private const string MESSAGE_FAILED = "File doesn't exists.";

        public GetDefaultPayrollFromFile(IEmployeeManager employeeManager, IPayrollConfigurationProvider payrollConfigurationProvider)
        {
            _EmployeeManager = employeeManager;
            _PayrollConfigurationProvider = payrollConfigurationProvider;

            Payroll = new Payroll();
            _FailedResult = new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FAILED);
        }

        private readonly IEmployeeManager _EmployeeManager;
        private readonly IPayrollConfigurationProvider _PayrollConfigurationProvider;
        private readonly IProcessResult<IPayroll> _FailedResult;

        public string FilePath { get; set; }
        private IPayroll Payroll { get; }
        private JObject Source { get; set; }
        private long MayorId;
        private long HumanResourceHeadId;
        private long TreasurerId;
        private long CityAccountantId;
        private long CityBudgetOfficerId;

        private bool TryInitialize()
        {
            if (File.Exists(FilePath))
            {
                Source = JObject.Parse(File.ReadAllText(FilePath));

                if (Source != null)
                {
                    InitializeValues();
                    return true;
                }
            }

            return false;
        }

        private void InitializeValues()
        {
            MayorId = Source.GetInt64(_PayrollConfigurationProvider.MayorId);
            HumanResourceHeadId = Source.GetInt64(_PayrollConfigurationProvider.HumanResourceHeadId);
            TreasurerId = Source.GetInt64(_PayrollConfigurationProvider.TreasurerId);
            CityAccountantId = Source.GetInt64(_PayrollConfigurationProvider.CityAccountantId);
            CityBudgetOfficerId = Source.GetInt64(_PayrollConfigurationProvider.CityBudgetOfficerId);
        }

        private IProcessResult<IPayroll> ConstructResult(
            IProcessResult<IEmployee> mayorResult,
            IProcessResult<IEmployee> humanResourceHeadResult,
            IProcessResult<IEmployee> treasurerResult,
            IProcessResult<IEmployee> cityAccountantResult,
            IProcessResult<IEmployee> cityBudgetOfficerResult)
        {
            Payroll.Mayor = mayorResult.Data;
            Payroll.HumanResourceHead = humanResourceHeadResult.Data;
            Payroll.Treasurer = treasurerResult.Data;
            Payroll.CityAccountant = cityAccountantResult.Data;
            Payroll.CityBudgetOfficer = cityBudgetOfficerResult.Data;

            return new ProcessResult<IPayroll>(Payroll);
        }

        public IProcessResult<IPayroll> Execute()
        {
            if (TryInitialize())
            {
                return ConstructResult(
                    _EmployeeManager.GetById(MayorId),
                    _EmployeeManager.GetById(HumanResourceHeadId),
                    _EmployeeManager.GetById(TreasurerId),
                    _EmployeeManager.GetById(CityAccountantId),
                    _EmployeeManager.GetById(CityBudgetOfficerId));
            }
            else
            {
                return _FailedResult;
            }
        }

        public async Task<IProcessResult<IPayroll>> ExecuteAsync()
        {
            if (TryInitialize())
            {
                return ConstructResult(
                    await _EmployeeManager.GetByIdAsync(MayorId),
                    await _EmployeeManager.GetByIdAsync(HumanResourceHeadId),
                    await _EmployeeManager.GetByIdAsync(TreasurerId),
                    await _EmployeeManager.GetByIdAsync(CityAccountantId),
                    await _EmployeeManager.GetByIdAsync(CityBudgetOfficerId));
            }
            else
            {
                return _FailedResult;
            }
        }

        public async Task<IProcessResult<IPayroll>> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (TryInitialize())
            {
                return ConstructResult(
                    await _EmployeeManager.GetByIdAsync(MayorId, cancellationToken),
                    await _EmployeeManager.GetByIdAsync(HumanResourceHeadId, cancellationToken),
                    await _EmployeeManager.GetByIdAsync(TreasurerId, cancellationToken),
                    await _EmployeeManager.GetByIdAsync(CityAccountantId, cancellationToken),
                    await _EmployeeManager.GetByIdAsync(CityBudgetOfficerId, cancellationToken));
            }
            else
            {
                return _FailedResult;
            }
        }
    }
}
