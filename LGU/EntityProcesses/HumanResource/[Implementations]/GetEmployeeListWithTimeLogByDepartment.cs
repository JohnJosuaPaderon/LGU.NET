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
    public sealed class GetEmployeeListWithTimeLogByDepartment : EmployeeProcess, IGetEmployeeListWithTimeLogByDepartment
    {
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GetEmployeeListWithTimeLogByDepartment(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter, IEmployeeParameters parameters) : base(connectionStringSource, converter)
        {
            _Parameters = parameters;
        }

        private readonly IEmployeeParameters _Parameters;

        public ValueRange<DateTime> CutOff { get; set; }
        public IDepartment Department { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.DepartmentId, Department?.Id)
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
