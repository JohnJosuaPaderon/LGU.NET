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
    public sealed class DeleteExamEssayAnswer : ExamEssayAnswerProcess, IDeleteExamEssayAnswer
    {
        public DeleteExamEssayAnswer(IConnectionStringSource connectionStringSource, IExamEssayAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExamEssayAnswer ExamEssayAnswer { get; set; }

        private SqlQueryInfo<IExamEssayAnswer> QueryInfo =>
            SqlQueryInfo<IExamEssayAnswer>.CreateProcedureQueryInfo(ExamEssayAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamEssayAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamEssayAnswer.Question?.Id)
            .AddLogByParameter();

        private IProcessResult<IExamEssayAnswer> GetProcessResult(IExamEssayAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IExamEssayAnswer>(data);
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Failed to delete exam essay answer.");
            }
        }

        public IProcessResult<IExamEssayAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamEssayAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamEssayAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
