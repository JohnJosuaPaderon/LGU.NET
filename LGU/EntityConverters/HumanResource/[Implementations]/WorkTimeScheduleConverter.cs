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
    public sealed class WorkTimeScheduleConverter : IWorkTimeScheduleConverter<SqlDataReader>
    {
        private IWorkTimeSchedule GetData(SqlDataReader reader)
        {
            return new WorkTimeSchedule()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                WorkTimeStart = reader.GetDateTime("WorkTimeStart"),
                WorkTImeEnd = reader.GetDateTime("WorkTimeEnd")
            };
        }

        public IEnumerableProcessResult<IWorkTimeSchedule> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public IProcessResult<IWorkTimeSchedule> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }
    }
}
