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
    public sealed class TimeLogTypeConverter : ITimeLogTypeConverter<SqlDataReader>
    {
        private ITimeLogType GetData(SqlDataReader reader)
        {
            return new TimeLogType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<ITimeLogType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ITimeLogType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ITimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLogType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ITimeLogType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ITimeLogType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ITimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLogType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ITimeLogType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ITimeLogType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ITimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLogType>(ex);
            }
        }

        public IProcessResult<ITimeLogType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ITimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLogType>(ex);
            }
        }

        public async Task<IProcessResult<ITimeLogType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ITimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLogType>(ex);
            }
        }

        public async Task<IProcessResult<ITimeLogType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ITimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLogType>(ex);
            }
        }
    }
}
