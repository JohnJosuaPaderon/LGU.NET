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
    public sealed class InsertApplicant : ApplicantProcess, IInsertApplicant
    {
        public InsertApplicant(IConnectionStringSource connectionStringSource, IApplicantConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Applicant Applicant { get; set; }

        private SqlQueryInfo<Applicant> QueryInfo =>
            SqlQueryInfo<Applicant>.CreateProcedureQueryInfo(Applicant, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
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

        private IProcessResult<Applicant> GetProcessResult(Applicant data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<Applicant>(data);
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Failed to insert applicant.");
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
