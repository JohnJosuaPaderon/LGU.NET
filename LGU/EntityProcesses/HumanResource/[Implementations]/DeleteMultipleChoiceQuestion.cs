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
    public sealed class DeleteMultipleChoiceQuestion : MultipleChoiceQuestionProcess, IDeleteMultipleChoiceQuestion
    {
        public DeleteMultipleChoiceQuestion(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IMultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        private SqlQueryInfo<IMultipleChoiceQuestion> QueryInfo =>
            SqlQueryInfo<IMultipleChoiceQuestion>.CreateProcedureQueryInfo(MultipleChoiceQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceQuestion.Id)
            .AddLogByParameter();

        private IProcessResult<IMultipleChoiceQuestion> GetProcessResult(IMultipleChoiceQuestion data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<IMultipleChoiceQuestion>(data) : new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Failed to delete multiple choice question.");
        }

        public IProcessResult<IMultipleChoiceQuestion> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
