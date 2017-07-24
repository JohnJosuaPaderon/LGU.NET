using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicantStatusConverter : IApplicantStatusConverter<SqlDataReader>
    {
        private ApplicantStatus GetData(SqlDataReader reader)
        {
            return new ApplicantStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<ApplicantStatus> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ApplicantStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicantStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ApplicantStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicantStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ApplicantStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicantStatus>(ex);
            }
        }

        public IProcessResult<ApplicantStatus> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicantStatus>(ex);
            }
        }

        public async Task<IProcessResult<ApplicantStatus>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicantStatus>(ex);
            }
        }

        public async Task<IProcessResult<ApplicantStatus>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicantStatus>(ex);
            }
        }
    }
}
