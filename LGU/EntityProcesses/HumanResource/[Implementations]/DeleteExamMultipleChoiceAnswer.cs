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
    public sealed class DeleteExamMultipleChoiceAnswer : ExamMultipleChoiceAnswerProcess, IDeleteExamMultipleChoiceAnswer
    {
        public DeleteExamMultipleChoiceAnswer(IConnectionStringSource connectionStringSource, IExamMultipleChoiceAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }

        private SqlQueryInfo<ExamMultipleChoiceAnswer> QueryInfo =>
            SqlQueryInfo<ExamMultipleChoiceAnswer>.CreateProcedureQueryInfo(ExamMultipleChoiceAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamMultipleChoiceAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamMultipleChoiceAnswer.Question?.Id)
            .AddLogByParameter();

        private IProcessResult<ExamMultipleChoiceAnswer> GetProcessResult(ExamMultipleChoiceAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(data);
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Failed to delete exam multiple choice answer.");
            }
        }

        public IProcessResult<ExamMultipleChoiceAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ExamMultipleChoiceAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ExamMultipleChoiceAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
