using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateEmployee : HumanResourceProcessBase, IUpdateEmployee
    {
        public UpdateEmployee(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Employee Employee { get; set; }

        private SqlDataQueryInfo<Employee> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Employee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName("UpdateEmployee"), GetProcessResult, true)
                    .AddInputParameter("@_Id", Employee.Id)
                    .AddInputParameter("@_FirstName", Employee.FirstName)
                    .AddInputParameter("@_MiddleName", Employee.MiddleName)
                    .AddInputParameter("@_LastName", Employee.LastName)
                    .AddInputParameter("@_NameExtension", Employee.NameExtension)
                    .AddInputParameter("@_DepartmentId", Employee.Department?.Id)
                    .AddLogByParameter();
            }
        }

        private IDataProcessResult<Employee> GetProcessResult(Employee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new DataProcessResult<Employee>(data);
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
