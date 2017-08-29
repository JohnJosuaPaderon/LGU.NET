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
    public sealed class UpdateEmployeeWorkTimeSchedule : EmployeeWorkTimeScheduleProcess, IUpdateEmployeeWorkTimeSchedule
    {
        public UpdateEmployeeWorkTimeSchedule(IConnectionStringSource connectionStringSource, IEmployeeWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployeeWorkTimeSchedule WorkTimeSchedule { get; set; }

        private SqlQueryInfo<IEmployeeWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<IEmployeeWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", WorkTimeSchedule.Id)
            .AddInputParameter("@_EmployeeId", WorkTimeSchedule.Employee?.Id)
            .AddInputParameter("@_WorkTimeStart", WorkTimeSchedule.WorkTimeStart)
            .AddInputParameter("@_WorkTimeEnd", WorkTimeSchedule.WorkTimeEnd)
            .AddInputParameter("@_EffectivityDate", WorkTimeSchedule.EffectivityDate)
            .AddInputParameter("@_IsEnabled", WorkTimeSchedule.IsEnabled)
            .AddInputParameter("@_InvocationLevel", WorkTimeSchedule.InvocationLevel)
            .AddInputParameter("@_WorkTimeLength", WorkTimeSchedule.WorkTimeLength.Ticks)
            .AddLogByParameter();

        private IProcessResult<IEmployeeWorkTimeSchedule> GetProcessResult(IEmployeeWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<IEmployeeWorkTimeSchedule>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to insert work time schedule.");
            }
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkTimeSchedule>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
