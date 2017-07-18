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
        private TimeLogType GetData(SqlDataReader reader)
        {
            return new TimeLogType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description"),
                WorkTimeLength = reader.GetTimeSpan("WorkTimeLength"),
                BreakTimeLength = reader.GetNullableTimeSpan("BreakTimeLength")
            };
        }

        public IEnumerableProcessResult<TimeLogType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLogType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<TimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLogType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLogType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<TimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLogType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<TimeLogType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<TimeLogType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLogType>(ex);
            }
        }

        public IProcessResult<TimeLogType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<TimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLogType>(ex);
            }
        }

        public async Task<IProcessResult<TimeLogType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<TimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLogType>(ex);
            }
        }

        public async Task<IProcessResult<TimeLogType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<TimeLogType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLogType>(ex);
            }
        }
    }
}
