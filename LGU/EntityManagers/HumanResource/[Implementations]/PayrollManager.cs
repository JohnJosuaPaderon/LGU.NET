using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollManager : EntityManagerBase<IPayroll, long>, IPayrollManager<SqlConnection, SqlTransaction>
    {
        private const string MESSAGE_INVALID = "Invalid payroll.";
        private const string MESSAGE_FILE_NOT_EXISTS = "File doesn't exists.";

        public PayrollManager(
            IInsertPayroll<SqlConnection, SqlTransaction> insert,
            IGetDefaultPayrollFromFile getDefaultFromFile,
            ISaveDefaultPayrollToFile saveDefaultPayrollToFile)
        {
            _Insert = insert;
            _GetDefaultFromFile = getDefaultFromFile;
            _SaveDefaultPayrollToFile = saveDefaultPayrollToFile;
        }

        private readonly IInsertPayroll<SqlConnection, SqlTransaction> _Insert;
        private readonly IGetDefaultPayrollFromFile _GetDefaultFromFile;
        private readonly ISaveDefaultPayrollToFile _SaveDefaultPayrollToFile;

        public IProcessResult<IPayroll> Insert(IPayroll payroll)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, CancellationToken cancellationToken)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return AddIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public IProcessResult<IPayroll> Insert(IPayroll payroll, SqlConnection connection, SqlTransaction transaction)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return _Insert.Execute(connection, transaction);
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, SqlConnection connection, SqlTransaction transaction)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return await _Insert.ExecuteAsync(connection, transaction);
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IPayroll>> InsertAsync(IPayroll payroll, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return await _Insert.ExecuteAsync(connection, transaction, cancellationToken);
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public IProcessResult<IPayroll> GetDefaultFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                _GetDefaultFromFile.FilePath = filePath;
                return _GetDefaultFromFile.Execute();
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FILE_NOT_EXISTS);
            }
        }

        public async Task<IProcessResult<IPayroll>> GetDefaultFromFileAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                _GetDefaultFromFile.FilePath = filePath;
                return await _GetDefaultFromFile.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FILE_NOT_EXISTS);
            }
        }

        public async Task<IProcessResult<IPayroll>> GetDefaultFromFileAsync(string filePath, CancellationToken cancellationToken)
        {
            if (File.Exists(filePath))
            {
                _GetDefaultFromFile.FilePath = filePath;
                return await _GetDefaultFromFile.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FILE_NOT_EXISTS);
            }
        }

        public IProcessResult SaveDefaultToFile(IPayroll payroll, string filePath)
        {
            if (payroll != null && !File.Exists(filePath))
            {
                _SaveDefaultPayrollToFile.Payroll = payroll;
                _SaveDefaultPayrollToFile.FilePath = filePath;

                return _SaveDefaultPayrollToFile.Execute();
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult> SaveDefaultToFileAsync(IPayroll payroll, string filePath)
        {
            if (payroll != null && !File.Exists(filePath))
            {
                _SaveDefaultPayrollToFile.Payroll = payroll;
                _SaveDefaultPayrollToFile.FilePath = filePath;

                return await _SaveDefaultPayrollToFile.ExecuteAsync();
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult> SaveDefaultToFileAsync(IPayroll payroll, string filePath, CancellationToken cancellationToken)
        {
            if (payroll != null && !File.Exists(filePath))
            {
                _SaveDefaultPayrollToFile.Payroll = payroll;
                _SaveDefaultPayrollToFile.FilePath = filePath;

                return await _SaveDefaultPayrollToFile.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Failed);
            }
        }
    }
}
