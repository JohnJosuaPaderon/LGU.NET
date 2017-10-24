using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertDepartmentHead : HumanResourceProcessBaseV2, IInsertDepartmentHead<SqlConnection, SqlTransaction>
    {
        private const string MESSAGE_FAILED = "Failed to insert department head.";

        public InsertDepartmentHead(IConnectionStringSource connectionStringSource, IDepartmentHeadParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IDepartmentHeadParameters _Parameters;

        public IDepartmentHead DepartmentHead { get; set; }

        private SqlQueryInfo<IDepartmentHead> QueryInfo =>
            SqlQueryInfo<IDepartmentHead>.CreateProcedureQueryInfo(DepartmentHead, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int32)
            .AddInputParameter(_Parameters.FirstName, DepartmentHead.FirstName)
            .AddInputParameter(_Parameters.MiddleName, DepartmentHead.MiddleName)
            .AddInputParameter(_Parameters.LastName, DepartmentHead.LastName)
            .AddInputParameter(_Parameters.NameExtension, DepartmentHead.NameExtension)
            .AddInputParameter(_Parameters.GenderId, DepartmentHead.Gender?.Id)
            .AddInputParameter(_Parameters.BirthDate, DepartmentHead.BirthDate)
            .AddInputParameter(_Parameters.Deceased, DepartmentHead.Deceased)
            .AddInputParameter(_Parameters.Title, DepartmentHead.Title)
            .AddLogByParameter();

        private IProcessResult<IDepartmentHead> GetProcessResult(IDepartmentHead data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32(_Parameters.Id);
                return new ProcessResult<IDepartmentHead>(DepartmentHead);
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IDepartmentHead> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }

        public IProcessResult<IDepartmentHead> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);
        }
    }
}
