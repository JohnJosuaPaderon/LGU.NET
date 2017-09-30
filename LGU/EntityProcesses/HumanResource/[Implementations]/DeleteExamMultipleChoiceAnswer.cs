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
    public sealed class DeleteExamMultipleChoiceAnswer : ExamMultipleChoiceAnswerProcess, IDeleteExamMultipleChoiceAnswer
    {
        public DeleteExamMultipleChoiceAnswer(IConnectionStringSource connectionStringSource, IExamMultipleChoiceAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }

        private SqlQueryInfo<IExamMultipleChoiceAnswer> QueryInfo =>
            SqlQueryInfo<IExamMultipleChoiceAnswer>.CreateProcedureQueryInfo(ExamMultipleChoiceAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_ExamId", ExamMultipleChoiceAnswer.Exam?.Id)
            .AddInputParameter("@_QuestionId", ExamMultipleChoiceAnswer.Question?.Id)
            .AddLogByParameter();

        private IProcessResult<IExamMultipleChoiceAnswer> GetProcessResult(IExamMultipleChoiceAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(data);
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Failed to delete exam multiple choice answer.");
            }
        }

        public IProcessResult<IExamMultipleChoiceAnswer> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamMultipleChoiceAnswer>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamMultipleChoiceAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
