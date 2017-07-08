using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteEmployee : HumanResourceProcessBase, IDeleteEmployee
    {
        public DeleteEmployee(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Employee Employee { get; set; }

        private SqlDataQueryInfo<Employee> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<Employee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName("DeleteEmployee"), GetProcessResult, true)
                    .AddOutputParameter("@_Id", DbType.Int64)
                    .AddInputParameter("@_FirstName", Employee.FirstName)
                    .AddInputParameter("@_MiddleName", Employee.MiddleName)
                    .AddInputParameter("@_LastName", Employee.LastName)
                    .AddInputParameter("@_NameExtension", Employee.NameExtension)
                    .AddInputParameter("@_DepartmentId", Employee.Department?.Id);
            }
        }

        private IDataProcessResult<Employee> GetProcessResult(Employee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetUInt64("@_Id");
                return new DataProcessResult<Employee>(data, ProcessResultStatus.Success);
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
