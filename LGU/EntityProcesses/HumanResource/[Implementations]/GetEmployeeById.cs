﻿using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeById : EmployeeProcess, IGetEmployeeById
    {
        public GetEmployeeById(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long EmployeeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", EmployeeId);

        public IDataProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter.FromReader);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync, cancellationToken);
        }
    }
}
