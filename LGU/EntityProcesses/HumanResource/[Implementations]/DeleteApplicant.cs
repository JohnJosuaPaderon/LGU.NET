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
    public sealed class DeleteApplicant : ApplicantProcess, IDeleteApplicant
    {
        public DeleteApplicant(IConnectionStringSource connectionStringSource, IApplicantConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Applicant Applicant { get; set; }

        private SqlQueryInfo<Applicant> QueryInfo =>
            SqlQueryInfo<Applicant>.CreateProcedureQueryInfo(Applicant, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Applicant.Id)
            .AddLogByParameter();

        private IProcessResult<Applicant> GetProcessResult(Applicant data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Applicant>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Failed to delete applicant.");
            }
        }

        public IProcessResult<Applicant> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Applicant>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Applicant>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
