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
    public sealed class UpdateMultipleChoiceQuestion : MultipleChoiceQuestionProcess, IUpdateMultipleChoiceQuestion
    {
        public UpdateMultipleChoiceQuestion(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IMultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        private SqlQueryInfo<IMultipleChoiceQuestion> QueryInfo =>
            SqlQueryInfo<IMultipleChoiceQuestion>.CreateProcedureQueryInfo(MultipleChoiceQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceQuestion.Id)
            .AddInputParameter("@_ExamSetId", MultipleChoiceQuestion.Set?.Id)
            .AddInputParameter("@_Description", MultipleChoiceQuestion.Description)
            .AddInputParameter("@_Points", MultipleChoiceQuestion.Points)
            .AddInputParameter("@_MaxAnswerCount", MultipleChoiceQuestion.MaxAnswerCount)
            .AddLogByParameter();

        private IProcessResult<IMultipleChoiceQuestion> GetProcessResult(IMultipleChoiceQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IMultipleChoiceQuestion>(data);
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Failed to update multiple choice question.");
            }
        }

        public IProcessResult<IMultipleChoiceQuestion> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
