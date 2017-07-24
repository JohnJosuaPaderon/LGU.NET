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
    public sealed class UpdateExamEssayAnswer : ExamEssayAnswerProcess, IUpdateExamEssayAnswer
    {
        public UpdateExamEssayAnswer(IConnectionStringSource connectionStringSource, IExamEssayAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ExamEssayAnswer ExamEssayAnswer { get; set; }

        private SqlQueryInfo<ExamEssayAnswer> QueryInfo =>
            SqlQueryInfo<ExamEssayAnswer>.CreateProcedureQueryInfo(ExamEssayAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamEssayAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamEssayAnswer.Question?.Id)
            .AddInputParameter("@_Description", ExamEssayAnswer.Description)
            .AddInputParameter("@_IsCorrect", ExamEssayAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<ExamEssayAnswer> GetProcessResult(ExamEssayAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ExamEssayAnswer>(data);
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Failed to update exam essay answer.");
            }
        }

        public IProcessResult<ExamEssayAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ExamEssayAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ExamEssayAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
