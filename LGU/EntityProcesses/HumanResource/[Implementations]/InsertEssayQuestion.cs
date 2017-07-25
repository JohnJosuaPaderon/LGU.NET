﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertEssayQuestion : EssayQuestionProcess, IInsertEssayQuestion
    {
        public InsertEssayQuestion(IConnectionStringSource connectionStringSource, IEssayQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EssayQuestion EssayQuestion { get; set; }

        private SqlQueryInfo<EssayQuestion> QueryInfo =>
            SqlQueryInfo<EssayQuestion>.CreateProcedureQueryInfo(EssayQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_SetId", EssayQuestion.Set?.Id)
            .AddInputParameter("@_Description", EssayQuestion.Description)
            .AddInputParameter("@_Points", EssayQuestion.Points)
            .AddInputParameter("@_MaxAnswerLength", EssayQuestion.MaxAnswerLength)
            .AddLogByParameter();

        private IProcessResult<EssayQuestion> GetProcessResult(EssayQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<EssayQuestion>(data);
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Failed to insert essay question.");
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