using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertExamMultipleChoiceAnswer : ExamMultipleChoiceAnswerProcess, IInsertExamMultipleChoiceAnswer
    {
        public InsertExamMultipleChoiceAnswer(IConnectionStringSource connectionStringSource, IExamMultipleChoiceAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }

        private SqlQueryInfo<IExamMultipleChoiceAnswer> QueryInfo =>
            SqlQueryInfo<IExamMultipleChoiceAnswer>.CreateProcedureQueryInfo(ExamMultipleChoiceAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamMultipleChoiceAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamMultipleChoiceAnswer.Question?.Id)
            .AddInputParameter("@_AnswerId", ExamMultipleChoiceAnswer.Answer?.Id)
            .AddInputParameter("@_IsCorrect", ExamMultipleChoiceAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<IExamMultipleChoiceAnswer> GetProcessResult(IExamMultipleChoiceAnswer data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<IExamMultipleChoiceAnswer>(data) : new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Failed to insert exam multiple choice answer.");
        }

        public IProcessResult<IExamMultipleChoiceAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamMultipleChoiceAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamMultipleChoiceAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
