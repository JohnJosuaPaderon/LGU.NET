using LGU.Data.Extensions;
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
    public sealed class InsertMultipleChoiceQuestion : MultipleChoiceQuestionProcess, IInsertMultipleChoiceQuestion
    {
        public InsertMultipleChoiceQuestion(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        private SqlQueryInfo<MultipleChoiceQuestion> QueryInfo =>
            SqlQueryInfo<MultipleChoiceQuestion>.CreateProcedureQueryInfo(MultipleChoiceQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_ExamSetId", MultipleChoiceQuestion.Set?.Id)
            .AddInputParameter("@_Description", MultipleChoiceQuestion.Description)
            .AddInputParameter("@_Points", MultipleChoiceQuestion.Points)
            .AddInputParameter("@_MaxAnswerCount", MultipleChoiceQuestion.MaxAnswerCount)
            .AddLogByParameter();

        private IProcessResult<MultipleChoiceQuestion> GetProcessResult(MultipleChoiceQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<MultipleChoiceQuestion>(data);
            }
            else
            {
                return new ProcessResult<MultipleChoiceQuestion>(ProcessResultStatus.Failed, "Failed to insert multiple choice question.");
            }
        }

        public IProcessResult<MultipleChoiceQuestion> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceQuestion>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
