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
    public sealed class DeleteEssayQuestion : EssayQuestionProcess, IDeleteEssayQuestion
    {
        public DeleteEssayQuestion(IConnectionStringSource connectionStringSource, IEssayQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EssayQuestion EssayQuestion { get; set; }

        private SqlQueryInfo<EssayQuestion> QueryInfo =>
            SqlQueryInfo<EssayQuestion>.CreateProcedureQueryInfo(EssayQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", EssayQuestion.Id)
            .AddLogByParameter();

        private IProcessResult<EssayQuestion> GetProcessResult(EssayQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<EssayQuestion>(data);
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Failed to delete essay question.");
            }
        }

        public IProcessResult<EssayQuestion> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<EssayQuestion>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<EssayQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}