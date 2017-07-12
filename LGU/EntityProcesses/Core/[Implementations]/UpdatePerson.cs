using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class UpdatePerson : CoreProcessBase, IUpdatePerson
    {
        public UpdatePerson(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Person Person { get; set; }

        private SqlDataQueryInfo<Person> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Person>.CreateProcedureQueryInfo(Person, GetQualifiedDbObjectName("UpdatePerson"), GetProcessResult, true)
                    .AddInputParameter("@_Id", Person.Id)
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
                return new DataProcessResult<Person>(data);
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed, "Failed to update person.");
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
