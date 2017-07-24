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
    public sealed class ApplicationStatusConverter : IApplicationStatusConverter<SqlDataReader>
    {
        private ApplicationStatus GetData(SqlDataReader reader)
        {
            return new ApplicationStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<ApplicationStatus> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ApplicationStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicationStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ApplicationStatus>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ApplicationStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicationStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ApplicationStatus>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ApplicationStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ApplicationStatus>(ex);
            }
        }

        public IProcessResult<ApplicationStatus> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicationStatus>(ex);
            }
        }

        public async Task<IProcessResult<ApplicationStatus>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicationStatus>(ex);
            }
        }

        public async Task<IProcessResult<ApplicationStatus>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ApplicationStatus>(ex);
            }
        }
    }
}
