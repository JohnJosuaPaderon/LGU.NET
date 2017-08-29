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
    public sealed class EmploymentStatusConverter : IEmploymentStatusConverter<SqlDataReader>
    {
        private IEmploymentStatus GetData(SqlDataReader reader)
        {
            return new EmploymentStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IEmploymentStatus> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmploymentStatus>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmploymentStatus>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public IProcessResult<IEmploymentStatus> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<IEmploymentStatus>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<IEmploymentStatus>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }
    }
}
