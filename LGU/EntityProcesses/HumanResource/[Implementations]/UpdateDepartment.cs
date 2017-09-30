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
    public sealed class UpdateDepartment : DepartmentProcess, IUpdateDepartment
    {
        public UpdateDepartment(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IDepartment Department { get; set; }

        public SqlQueryInfo<IDepartment> QueryInfo =>
            SqlQueryInfo<IDepartment>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Department.Id)
            .AddInputParameter("@_Description", Department.Description)
            .AddInputParameter("@_Abbreviation", Department.Abbreviation)
            .AddInputParameter("@_HeadId", Department.Head?.Id)
            .AddLogByParameter();

        private IProcessResult<IDepartment> GetProcessResult(IDepartment data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IDepartment>(Department);
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<IDepartment> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
