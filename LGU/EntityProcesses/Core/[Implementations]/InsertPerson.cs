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
        public InsertPerson(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Person Person { get; set; }

        private SqlQueryInfo<Person> QueryInfo
        {
            get
            {
                return SqlQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName(), GetProcessResult, true)
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

        private IProcessResult<Person> GetProcessResult(Person data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetInt16("@_Id");
                return new ProcessResult<Person>(data);
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Failed to insert person.");
            }
        }

        public IProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
