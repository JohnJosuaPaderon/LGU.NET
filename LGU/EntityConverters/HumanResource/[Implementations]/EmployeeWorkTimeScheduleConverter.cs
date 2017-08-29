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
    public sealed class EmployeeWorkTimeScheduleConverter : IEmployeeWorkTimeScheduleConverter<SqlDataReader>
    {
        private readonly IEmployeeManager r_EmployeeManager;

        public EmployeeWorkTimeScheduleConverter(IEmployeeManager employeeManager)
        {
            r_EmployeeManager = employeeManager;
        }

        private IEmployeeWorkTimeSchedule GetData(IEmployee employee, SqlDataReader reader)
        {
            if (employee != null)
            {
                return new EmployeeWorkTimeSchedule(employee)
                {
                    Id = reader.GetInt64("Id"),
                    WorkTimeStart = reader.GetDateTime("WorkTimeStart"),
                    WorkTimeEnd = reader.GetDateTime("WorkTimeEnd"),
                    EffectivityDate = reader.GetNullableDateTime("EffectivityDate"),
                    IsEnabled = reader.GetBoolean("IsEnabled"),
                    InvocationLevel = reader.GetInt32("InvocationLevel"),
                    WorkTimeLength = reader.GetTimeSpan("WorkTimeLength")
                };
            }
            else
            {
                return null;
            }
        }

        private IEmployeeWorkTimeSchedule GetData(SqlDataReader reader)
        {
            var employeeResult = r_EmployeeManager.GetById(reader.GetInt64("EmployeeId"));
            return GetData(employeeResult.Data, reader);
        }

        private async Task<IEmployeeWorkTimeSchedule> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));
            return GetData(employeeResult.Data, reader);
        }

        private async Task<IEmployeeWorkTimeSchedule> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);
            return GetData(employeeResult.Data, reader);
        }

        public IEnumerableProcessResult<IEmployeeWorkTimeSchedule> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeWorkTimeSchedule>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeWorkTimeSchedule>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeWorkTimeSchedule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeWorkTimeSchedule>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeWorkTimeSchedule>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ex);
            }
        }
    }
}
