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
    public sealed class TimeLogConverter : ITimeLogConverter<SqlDataReader>
    {
        private readonly IEmployeeManager r_EmployeeManager;
        private readonly ITimeLogTypeManager r_TimeLogTypeManager;

        public TimeLogConverter(
            IEmployeeManager employeeManager,
            ITimeLogTypeManager timeLogTypeManager)
        {
            r_EmployeeManager = employeeManager;
            r_TimeLogTypeManager = timeLogTypeManager;
        }

        private TimeLog GetData(Employee employee, TimeLogType type, SqlDataReader reader)
        {
            if (employee != null)
            {
                return new TimeLog(employee)
                {
                    Id = reader.GetInt64("Id"),
                    LoginDate = reader.GetNullableDateTime("LoginDate"),
                    LogoutDate = reader.GetNullableDateTime("LogoutDate"),
                    Type = type,
                    State = reader.GetNullableBoolean("State")
                };
            }
            else
            {
                return null;
            }
        }

        private TimeLog GetData(SqlDataReader reader)
        {
            var employeeResult = r_EmployeeManager.GetById(reader.GetInt64("EmployeeId"));
            var typeResult = r_TimeLogTypeManager.GetById(reader.GetInt16("TypeId"));

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        private async Task<TimeLog> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));
            var typeResult = await r_TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        private async Task<TimeLog> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);
            var typeResult = await r_TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        public IEnumerableProcessResult<TimeLog> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLog>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLog>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<TimeLog>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<TimeLog>(ex);
            }
        }

        public IProcessResult<TimeLog> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<TimeLog>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IProcessResult<TimeLog>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<TimeLog>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IProcessResult<TimeLog>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<TimeLog>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<TimeLog>(ex);
            }
        }
    }
}
