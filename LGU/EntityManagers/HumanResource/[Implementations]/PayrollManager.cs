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
        private const string MESSAGE_INVALID_IDENTIFIER = "Invalid payroll identifier.";

        public PayrollManager(
            IInsertPayroll<SqlConnection, SqlTransaction> insert,
            IGetDefaultPayrollFromFile getDefaultFromFile,
            ISaveDefaultPayrollToFile saveDefaultPayrollToFile,
            IGetPayrollById getById)
        {
            _Insert = insert;
            _GetDefaultFromFile = getDefaultFromFile;
            _SaveDefaultPayrollToFile = saveDefaultPayrollToFile;
            _GetById = getById;

            _InvalidIdentifierResult = new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID_IDENTIFIER);
            _InvalidResult = new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _FileNotExistsResult = new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FILE_NOT_EXISTS);
            _FailedResult = new ProcessResult<IPayroll>(ProcessResultStatus.Failed);
        }

        private readonly IInsertPayroll<SqlConnection, SqlTransaction> _Insert;
        private readonly IGetDefaultPayrollFromFile _GetDefaultFromFile;
        private readonly ISaveDefaultPayrollToFile _SaveDefaultPayrollToFile;
        private readonly IGetPayrollById _GetById;
        private readonly IProcessResult<IPayroll> _InvalidResult;
        private readonly IProcessResult<IPayroll> _FileNotExistsResult;
        private readonly IProcessResult<IPayroll> _InvalidIdentifierResult;
        private readonly IProcessResult<IPayroll> _FailedResult;

        public IProcessResult<IPayroll> Insert(IPayroll payroll)
        {
            if (payroll != null)
            {
                _Insert.Payroll = payroll;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
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
                return _InvalidResult;
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
                return _InvalidResult;
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
                return _InvalidResult;
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
                return _InvalidResult;
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
                return _InvalidResult;
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
                return _FileNotExistsResult;
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
                return _FileNotExistsResult;
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
                return _FileNotExistsResult;
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
                return _FailedResult;
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
                return _FailedResult;
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
                return _FailedResult;
            }
        }

        public IProcessResult<IPayroll> GetById(long payrollId)
        {
            if (payrollId > 0)
            {
                if (StaticSource.ContainsId(payrollId))
                {
                    return new ProcessResult<IPayroll>(StaticSource[payrollId]);
                }
                else
                {
                    _GetById.PayrollId = payrollId;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IPayroll>> GetByIdAsync(long payrollId)
        {
            if (payrollId > 0)
            {
                if (StaticSource.ContainsId(payrollId))
                {
                    return new ProcessResult<IPayroll>(StaticSource[payrollId]);
                }
                else
                {
                    _GetById.PayrollId = payrollId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IPayroll>> GetByIdAsync(long payrollId, CancellationToken cancellationToken)
        {
            if (payrollId > 0)
            {
                if (StaticSource.ContainsId(payrollId))
                {
                    return new ProcessResult<IPayroll>(StaticSource[payrollId]);
                }
                else
                {
                    _GetById.PayrollId = payrollId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }
    }
}
