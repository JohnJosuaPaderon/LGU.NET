﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetTimeLogListByDepartmentCutOff : TimeLogProcess, IGetTimeLogListByDepartmentCutOff
    {
        public GetTimeLogListByDepartmentCutOff(IConnectionStringSource connectionStringSource, ITimeLogConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Department Department { get; set; }
        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_DepartmentId", Department?.Id)
            .AddInputParameter("@_CutOffBegin", CutOff.Begin)
            .AddInputParameter("@_CutOffEnd", CutOff.End);

        public IEnumerableProcessResult<TimeLog> Execute()
        {
            return r_SqlHelper.ExecuteReaderEnumerable(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<TimeLog>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<TimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}