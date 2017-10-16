using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class InsertPerson : PersonProcess, IInsertPerson
    {
        public InsertPerson(IConnectionStringSource connectionStringSource, IPersonConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IPerson Person { get; set; }

        private SqlQueryInfo<IPerson> QueryInfo
        {
            get
            {
                return SqlQueryInfo<IPerson>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
                    .AddOutputParameter("@_Id", DbType.Int16)
                    .AddInputParameter("@_FirstName", Person.FirstName)
                    .AddInputParameter("@_MiddleName", Person.MiddleName)
                    .AddInputParameter("@_LastName", Person.LastName)
                    .AddInputParameter("@_NameExtension", Person.NameExtension)
                    .AddInputParameter("@_GenderId", Person.Gender?.Id)
                    .AddInputParameter("@_BirthDate", Person.BirthDate)
                    .AddInputParameter("@_Deceased", Person.Deceased)
                    .AddLogByParameter();
            }
        }

        private IProcessResult<IPerson> GetProcessResult(IPerson data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt16("@_Id");
                return new ProcessResult<IPerson>(data);
            }
            else
            {
                return new ProcessResult<IPerson>(ProcessResultStatus.Failed, "Failed to insert person.");
            }
        }

        public IProcessResult<IPerson> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
