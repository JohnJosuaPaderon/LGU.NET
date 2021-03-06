﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteDepartment : DepartmentProcess, IDeleteDepartment
    {
        public DeleteDepartment(IConnectionStringSource connectionStringSource, IDepartmentConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IDepartment Department { get; set; }

        private SqlQueryInfo<IDepartment> QueryInfo =>
            SqlQueryInfo<IDepartment>.CreateProcedureQueryInfo(Department, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("Id", Department.Id)
                .AddLogByParameter();

        private IProcessResult<IDepartment> GetProcessResult(IDepartment department, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IDepartment>(department);
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Failed to delete department.");
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
