using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateDepartmentHead : DepartmentHeadProcess, IUpdateDepartmentHead
    {
        public UpdateDepartmentHead(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IDepartmentHead DepartmentHead { get; set; }

        public SqlQueryInfo<IDepartmentHead> QueryInfo =>
            SqlQueryInfo<IDepartmentHead>.CreateProcedureQueryInfo(DepartmentHead, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", DepartmentHead.Id)
            .AddInputParameter("@_FirstName", DepartmentHead.FirstName)
            .AddInputParameter("@_MiddleName", DepartmentHead.MiddleName)
            .AddInputParameter("@_LastName", DepartmentHead.LastName)
            .AddInputParameter("@_NameExtension", DepartmentHead.NameExtension)
            .AddInputParameter("@_GenderId", DepartmentHead.Gender?.Id)
            .AddInputParameter("@_BirthDate", DepartmentHead.BirthDate)
            .AddInputParameter("@_Deceased", DepartmentHead.Deceased)
            .AddInputParameter("@_Title", DepartmentHead.Title)
            .AddLogByParameter();

        private IProcessResult<IDepartmentHead> GetProcessResult(IDepartmentHead data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IDepartmentHead>(DepartmentHead);
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<IDepartmentHead> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
