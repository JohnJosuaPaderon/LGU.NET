using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicantConverter : IApplicantConverter<SqlDataReader>
    {
        private readonly IGenderManager r_GenderManager;
        private readonly IApplicantStatusManager r_ApplicantStatusManager;

        public ApplicantConverter(IGenderManager genderManager, IApplicantStatusManager applicantStatusManager)
        {
            r_GenderManager = genderManager;
            r_ApplicantStatusManager = applicantStatusManager;
        }

        private Applicant GetData(Gender gender, ApplicantStatus status, SqlDataReader reader)
        {
            return new Applicant()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Gender = gender,
                Deceased = reader.GetBoolean("Deceased"),
                Status = status,
                ContactNumber = reader.GetString("ContactNumber")
            };
        }

        private Applicant GetData(SqlDataReader reader)
        {
            var genderResult = r_GenderManager.GetById(reader.GetInt16("GenderId"));
            var statusResult = r_ApplicantStatusManager.GetById(reader.GetInt16("StatusId"));

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        private async Task<Applicant> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));
            var statusResult = await r_ApplicantStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        private async Task<Applicant> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);
            var statusResult = await r_ApplicantStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        public IEnumerableProcessResult<Applicant> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Applicant>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Applicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Applicant>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Applicant>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Applicant>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<Applicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Applicant>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Applicant>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Applicant>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<Applicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Applicant>(ex);
            }
        }

        public IProcessResult<Applicant> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Applicant>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Applicant>(ex);
            }
        }

        public async Task<IProcessResult<Applicant>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Applicant>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Applicant>(ex);
            }
        }

        public async Task<IProcessResult<Applicant>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Applicant>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Applicant>(ex);
            }
        }
    }
}
