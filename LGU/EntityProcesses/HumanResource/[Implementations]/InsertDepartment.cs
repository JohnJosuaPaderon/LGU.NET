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
    public sealed class InsertDepartment : DepartmentProcess, IInsertDepartment
    {
        public InsertDepartment(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IDepartment Department { get; set; }

        private SqlQueryInfo<IDepartment> QueryInfo =>
            SqlQueryInfo<IDepartment>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_Description", Department.Description)
            .AddInputParameter("@_Abbreviation", Department.Abbreviation)
            .AddInputParameter("@_HeadId", Department.Head?.Id)
            .AddLogByParameter();

        private IProcessResult<IDepartment> GetProcessResult(IDepartment data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<IDepartment>(Department);
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Failed to insert department.");
            }
        }

        public IProcessResult<IDepartment> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
