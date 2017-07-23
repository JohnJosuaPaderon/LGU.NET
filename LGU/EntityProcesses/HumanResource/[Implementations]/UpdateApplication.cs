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
    public sealed class UpdateApplication : ApplicationProcess, IUpdateApplication
    {
        public UpdateApplication(IConnectionStringSource connectionStringSource, IApplicationConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Application Application { get; set; }

        private SqlQueryInfo<Application> QueryInfo =>
            SqlQueryInfo<Application>.CreateProcedureQueryInfo(Application, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Application.Id)
            .AddInputParameter("@_ApplicantId", Application.Applicant?.Id)
            .AddInputParameter("@_StatusId", Application.Status?.Id)
            .AddInputParameter("@_Date", Application.Date)
            .AddInputParameter("@_ApplyingPositionId", Application.ApplyingPosition?.Id)
            .AddLogByParameter();

        private IProcessResult<Application> GetProcessResult(Application data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Application>(data);
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Failed to update application.");
            }
        }

        public IProcessResult<Application> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Application>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Application>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
