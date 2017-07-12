using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class InsertPerson : CoreProcessBase, IInsertPerson
    {
        public InsertPerson(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Person Person { get; set; }

        private SqlDataQueryInfo<Person> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName("InsertPerson"), GetProcessResult, true)
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

        private IDataProcessResult<Person> GetProcessResult(Person data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetInt16("@_Id");
                return new DataProcessResult<Person>(data);
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed, "Failed to insert person.");
            }
        }

        public IDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
