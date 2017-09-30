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

        public IExamEssayAnswer ExamEssayAnswer { get; set; }

        private SqlQueryInfo<IExamEssayAnswer> QueryInfo =>
            SqlQueryInfo<IExamEssayAnswer>.CreateProcedureQueryInfo(ExamEssayAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamEssayAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamEssayAnswer.Question?.Id)
            .AddInputParameter("@_Description", ExamEssayAnswer.Description)
            .AddInputParameter("@_IsCorrect", ExamEssayAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<IExamEssayAnswer> GetProcessResult(IExamEssayAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IExamEssayAnswer>(data);
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Failed to update exam essay answer.");
            }
        }

        public IProcessResult<IExamEssayAnswer> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamEssayAnswer>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamEssayAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
