using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertDepartmentHead : DepartmentHeadProcess, IInsertDepartmentHead
    {
        public InsertDepartmentHead(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public DepartmentHead DepartmentHead { get; set; }

        private SqlQueryInfo<DepartmentHead> QueryInfo =>
            SqlQueryInfo<DepartmentHead>.CreateProcedureQueryInfo(DepartmentHead, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_FirstName", DepartmentHead.FirstName)
            .AddInputParameter("@_MiddleName", DepartmentHead.MiddleName)
            .AddInputParameter("@_LastName", DepartmentHead.LastName)
            .AddInputParameter("@_NameExtension", DepartmentHead.NameExtension)
            .AddInputParameter("@_GenderId", DepartmentHead.Gender?.Id)
            .AddInputParameter("@_BirthDate", DepartmentHead.BirthDate)
            .AddInputParameter("@_Deceased", DepartmentHead.Deceased)
            .AddInputParameter("@_Title", DepartmentHead.Title)
            .AddLogByParameter();

        private IProcessResult<DepartmentHead> GetProcessResult(DepartmentHead data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<DepartmentHead>(DepartmentHead);
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Failed to insert department head.");
            }
        }

        public IProcessResult<DepartmentHead> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<DepartmentHead>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<DepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
