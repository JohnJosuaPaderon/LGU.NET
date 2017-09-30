using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollManager : EntityManagerBase<IPayroll, long>, IPayrollManager<SqlConnection, SqlTransaction>
    {
        private const string MESSAGE_INVALID = "Invalid payroll.";

        public PayrollManager(IInsertPayroll<SqlConnection, SqlTransaction> insert)
        {
            _Insert = insert;
        }

        private readonly IInsertPayroll<SqlConnection, SqlTransaction> _Insert;

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
    }
}
