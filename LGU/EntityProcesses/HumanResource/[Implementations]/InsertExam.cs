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

        public Exam Exam { get; set; }

        private SqlQueryInfo<Exam> QueryInfo =>
            SqlQueryInfo<Exam>.CreateProcedureQueryInfo(Exam, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_ApplicationId", Exam.Application?.Id)
            .AddInputParameter("@_Date", Exam.Date)
            .AddInputParameter("@_SetId", Exam.Set?.Id)
            .AddInputParameter("@_TotalScore", Exam.TotalScore)
            .AddLogByParameter();

        private IProcessResult<Exam> GetProcessResult(Exam data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<Exam>(data);
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Failed to insert exam.");
            }
        }

        public IProcessResult<Exam> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Exam>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Exam>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
