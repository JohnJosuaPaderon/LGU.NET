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
    public sealed class InsertExam : ExamProcess, IInsertExam
    {
        public InsertExam(IConnectionStringSource connectionStringSource, IExamConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExam Exam { get; set; }

        private SqlQueryInfo<IExam> QueryInfo =>
            SqlQueryInfo<IExam>.CreateProcedureQueryInfo(Exam, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_ApplicationId", Exam.Application?.Id)
            .AddInputParameter("@_Date", Exam.Date)
            .AddInputParameter("@_SetId", Exam.Set?.Id)
            .AddInputParameter("@_TotalScore", Exam.TotalScore)
            .AddLogByParameter();

        private IProcessResult<IExam> GetProcessResult(IExam data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<IExam>(data);
            }
            else
            {
                return new ProcessResult<IExam>(ProcessResultStatus.Failed, "Failed to insert exam.");
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
