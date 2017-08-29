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
    public sealed class UpdateApplicant : ApplicantProcess, IUpdateApplicant
    {
        public UpdateApplicant(IConnectionStringSource connectionStringSource, IApplicantConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IApplicant Applicant { get; set; }

        private SqlQueryInfo<IApplicant> QueryInfo =>
            SqlQueryInfo<IApplicant>.CreateProcedureQueryInfo(Applicant, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Applicant.Id)
            .AddInputParameter("@_FirstName", Applicant.FirstName)
            .AddInputParameter("@_MiddleName", Applicant.MiddleName)
            .AddInputParameter("@_LastName", Applicant.LastName)
            .AddInputParameter("@_NameExtension", Applicant.NameExtension)
            .AddInputParameter("@_BirthDate", Applicant.BirthDate)
            .AddInputParameter("@_GenderId", Applicant.Gender?.Id)
            .AddInputParameter("@_Deceased", Applicant.Deceased)
            .AddInputParameter("@_StatusId", Applicant.Status?.Id)
            .AddInputParameter("@_ContactNumber", Applicant.ContactNumber)
            .AddLogByParameter();

        private IProcessResult<IApplicant> GetProcessResult(IApplicant data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplicant>(data);
            }
            else
            {
                return new ProcessResult<IApplicant>(ProcessResultStatus.Failed, "Failed to update applicant.");
            }
        }

        public IProcessResult<IApplicant> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IApplicant>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplicant>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
