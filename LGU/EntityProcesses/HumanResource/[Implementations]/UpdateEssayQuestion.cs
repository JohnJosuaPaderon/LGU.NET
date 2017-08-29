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
    public sealed class UpdateEssayQuestion : EssayQuestionProcess, IUpdateEssayQuestion
    {
        public UpdateEssayQuestion(IConnectionStringSource connectionStringSource, IEssayQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEssayQuestion EssayQuestion { get; set; }

        private SqlQueryInfo<IEssayQuestion> QueryInfo =>
            SqlQueryInfo<IEssayQuestion>.CreateProcedureQueryInfo(EssayQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", EssayQuestion.Id)
            .AddInputParameter("@_SetId", EssayQuestion.Set?.Id)
            .AddInputParameter("@_Description", EssayQuestion.Description)
            .AddInputParameter("@_Points", EssayQuestion.Points)
            .AddInputParameter("@_MaxAnswerLength", EssayQuestion.MaxAnswerLength)
            .AddLogByParameter();

        private IProcessResult<IEssayQuestion> GetProcessResult(IEssayQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEssayQuestion>(data);
            }
            else
            {
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Failed to update essay question.");
            }
        }

        public IProcessResult<IEssayQuestion> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEssayQuestion>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEssayQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
