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
    public sealed class DeleteExam : ExamProcess, IDeleteExam
    {
        public DeleteExam(IConnectionStringSource connectionStringSource, IExamConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExam Exam { get; set; }

        private SqlQueryInfo<IExam> QueryInfo =>
            SqlQueryInfo<IExam>.CreateProcedureQueryInfo(Exam, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Exam.Id)
            .AddLogByParameter();

        private IProcessResult<IExam> GetProcessResult(IExam data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IExam>(data);
            }
            else
            {
                return new ProcessResult<IExam>(ProcessResultStatus.Failed, "Failed to delete exam.");
            }
        }

        public IProcessResult<IExam> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExam>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExam>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
