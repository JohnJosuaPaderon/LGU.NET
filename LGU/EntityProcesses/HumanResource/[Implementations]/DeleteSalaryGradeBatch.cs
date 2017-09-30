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
    public sealed class DeleteSalaryGradeBatch : SalaryGradeBatchProcess, IDeleteSalaryGradeBatch
    {
        public DeleteSalaryGradeBatch(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGradeBatch SalaryGradeBatch { get; set; }

        private SqlQueryInfo<ISalaryGradeBatch> QueryInfo =>
            SqlQueryInfo<ISalaryGradeBatch>.CreateProcedureQueryInfo(SalaryGradeBatch, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", SalaryGradeBatch.Id)
            .AddLogByParameter();

        private IProcessResult<ISalaryGradeBatch> GetProcessResult(ISalaryGradeBatch data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ISalaryGradeBatch>(data);
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Failed to delete salary grade batch.");
            }
        }

        public IProcessResult<ISalaryGradeBatch> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
