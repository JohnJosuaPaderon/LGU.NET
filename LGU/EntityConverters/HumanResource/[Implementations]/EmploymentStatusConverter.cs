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
        private EmploymentStatus GetData(SqlDataReader reader)
        {
            return new EmploymentStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<EmploymentStatus> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmploymentStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EmploymentStatus>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmploymentStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EmploymentStatus>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<EmploymentStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmploymentStatus>(ex);
            }
        }

        public IProcessResult<EmploymentStatus> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<EmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<EmploymentStatus>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<EmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<EmploymentStatus>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<EmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmploymentStatus>(ex);
            }
        }
    }
}
