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
    public sealed class UpdateExamSet : ExamSetProcess, IUpdateExamSet
    {
        public UpdateExamSet(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IExamSet ExamSet { get; set; }

        private SqlQueryInfo<IExamSet> QueryInfo =>
            SqlQueryInfo<IExamSet>.CreateProcedureQueryInfo(ExamSet, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", ExamSet.Id)
            .AddInputParameter("@_Description", ExamSet.Description)
            .AddInputParameter("@_PassingScore", ExamSet.PassingScore)
            .AddLogByParameter();

        private IProcessResult<IExamSet> GetProcessResult(IExamSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IExamSet>(data);
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Failed to update exam set.");
            }
        }

        public IProcessResult<IExamSet> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
