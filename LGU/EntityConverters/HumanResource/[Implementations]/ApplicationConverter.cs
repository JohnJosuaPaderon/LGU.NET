using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicationConverter : IApplicationConverter<SqlDataReader>
    {
        private readonly IApplicantManager r_ApplicantManager;
        private readonly IApplicationStatusManager r_ApplicationStatusManager;
        private readonly IPositionManager r_PositionManager;

        public ApplicationConverter(
            IApplicantManager applicantManager,
            IApplicationStatusManager applicationStatusManager,
            IPositionManager positionManager)
        {
            r_ApplicantManager = applicantManager;
            r_ApplicationStatusManager = applicationStatusManager;
            r_PositionManager = positionManager;
        }

        private Application GetData(Applicant applicant, ApplicationStatus status, Position applyingPosition, SqlDataReader reader)
        {
            if (applicant != null)
            {
                return new Application(applicant)
                {
                    Id = reader.GetInt64("Id"),
                    Status = status,
                    Date = reader.GetDateTime("Date"),
                    ApplyingPosition = applyingPosition
                };
            }
            else
            {
                return null;
            }
        }

        private Application GetData(SqlDataReader reader)
        {
            var applicantResult = r_ApplicantManager.GetById(reader.GetInt64("ApplicantId"));
            var statusResult = r_ApplicationStatusManager.GetById(reader.GetInt16("StatusId"));
            var applyingPositionResult = r_PositionManager.GetById(reader.GetInt16("ApplyingPositionId"));

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        private async Task<Application> GetDataAsync(SqlDataReader reader)
        {
            var applicantResult = await r_ApplicantManager.GetByIdAsync(reader.GetInt64("ApplicantId"));
            var statusResult = await r_ApplicationStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));
            var applyingPositionResult = await r_PositionManager.GetByIdAsync(reader.GetInt16("ApplyingPositionId"));

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        private async Task<Application> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var applicantResult = await r_ApplicantManager.GetByIdAsync(reader.GetInt64("ApplicantId"), cancellationToken);
            var statusResult = await r_ApplicationStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);
            var applyingPositionResult = await r_PositionManager.GetByIdAsync(reader.GetInt16("ApplyingPositionId"), cancellationToken);

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        public IEnumerableProcessResult<Application> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Application>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Application>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Application>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Application>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Application>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Application>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Application>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Application>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Application>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Application>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Application>(ex);
            }
        }

        public IProcessResult<Application> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Application>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Application>(ex);
            }
        }

        public async Task<IProcessResult<Application>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Application>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Application>(ex);
            }
        }

        public async Task<IProcessResult<Application>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Application>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Application>(ex);
            }
        }
    }
}
