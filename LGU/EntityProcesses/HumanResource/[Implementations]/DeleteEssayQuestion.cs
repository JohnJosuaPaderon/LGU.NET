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
    public sealed class DeleteEssayQuestion : EssayQuestionProcess, IDeleteEssayQuestion
    {
        public DeleteEssayQuestion(IConnectionStringSource connectionStringSource, IEssayQuestionConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IEssayQuestion EssayQuestion { get; set; }

        private SqlQueryInfo<IEssayQuestion> QueryInfo =>
            SqlQueryInfo<IEssayQuestion>.CreateProcedureQueryInfo(EssayQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", EssayQuestion.Id)
            .AddLogByParameter();

        private IProcessResult<IEssayQuestion> GetProcessResult(IEssayQuestion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEssayQuestion>(data);
            }
            else
            {
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Failed to delete essay question.");
            }
        }

        public IProcessResult<IEssayQuestion> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEssayQuestion>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEssayQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
