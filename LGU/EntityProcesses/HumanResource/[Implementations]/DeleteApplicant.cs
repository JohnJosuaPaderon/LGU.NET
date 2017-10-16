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
        public DeleteApplicant(IConnectionStringSource connectionStringSource, IApplicantConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IApplicant Applicant { get; set; }

        private SqlQueryInfo<IApplicant> QueryInfo =>
            SqlQueryInfo<IApplicant>.CreateProcedureQueryInfo(Applicant, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Applicant.Id)
            .AddLogByParameter();

        private IProcessResult<IApplicant> GetProcessResult(IApplicant data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplicant>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IApplicant>(ProcessResultStatus.Failed, "Failed to delete applicant.");
            }
        }

        public IProcessResult<IApplicant> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IApplicant>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplicant>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
