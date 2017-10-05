using LGU.Entities.HumanResource;
using LGU.Processes;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class SaveDefaultPayrollToFile : ISaveDefaultPayrollToFile
    {
        public SaveDefaultPayrollToFile(IPayrollConfigurationProvider payrollConfigurationProvider)
        {
            _PayrollConfigurationProvider = payrollConfigurationProvider;
        }

        private readonly IPayrollConfigurationProvider _PayrollConfigurationProvider;

        public IPayroll Payroll { get; set; }
        public string FilePath { get; set; }

        private JObject Source;

        private void Initialize()
        {
            Source = new JObject();
            Source.Add(_PayrollConfigurationProvider.MayorId, Payroll.Mayor?.Id);
            Source.Add(_PayrollConfigurationProvider.HumanResourceHeadId, Payroll.HumanResourceHead?.Id);
            Source.Add(_PayrollConfigurationProvider.TreasurerId, Payroll.Treasurer?.Id);
            Source.Add(_PayrollConfigurationProvider.CityAccountantId, Payroll.CityAccountant?.Id);
            Source.Add(_PayrollConfigurationProvider.CityBudgetOfficerId, Payroll.CityBudgetOfficer?.Id);
        }

        private IProcessResult ConstructResult()
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IProcessResult Execute()
        {
            Initialize();

            using (var writer = new StreamWriter(FilePath))
            {
                writer.Write(Source.ToString());
            }

            return ConstructResult();
        }

        public async Task<IProcessResult> ExecuteAsync()
        {
            Initialize();

            using (var writer = new StreamWriter(FilePath))
            {
                await writer.WriteAsync(Source.ToString());
            }

            return ConstructResult();
        }

        public async Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            Initialize();

            using (var writer = new StreamWriter(FilePath))
            {
                await writer.WriteAsync(Source.ToString());
            }

            return ConstructResult();
        }
    }
}
