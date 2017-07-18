﻿using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentList : DepartmentProcess, IGetDepartmentList
    {
        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public GetDepartmentList(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEnumerableProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, Converter.EnumerableFromReader);
        }

        public Task<IEnumerableProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}
