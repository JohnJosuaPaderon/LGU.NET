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
        private readonly IEmployeeManager EmployeeManager;
        private readonly ITimeLogTypeManager TimeLogTypeManager;

        public TimeLogConverter(
            IEmployeeManager employeeManager,
            ITimeLogTypeManager timeLogTypeManager)
        {
            EmployeeManager = employeeManager;
            TimeLogTypeManager = timeLogTypeManager;
        }

        private TimeLog GetData(SqlDataReader reader)
        {
            var employeeResult = EmployeeManager.GetById(reader.GetInt64("EmployeeId"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var typeResult = TimeLogTypeManager.GetById(reader.GetInt16("TypeId"));

                return new TimeLog(employeeResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    LoginDate = reader.GetNullableDateTime("LoginDate"),
                    LogoutDate = reader.GetNullableDateTime("LogoutDate"),
                    Type = typeResult.Data
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<TimeLog> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var typeResult = await TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

                return new TimeLog(employeeResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    LoginDate = reader.GetNullableDateTime("LoginDate"),
                    LogoutDate = reader.GetNullableDateTime("LogoutDate"),
                    Type = typeResult.Data
                };
            }
            else
            {
                return null;
            }
        }

        private async Task<TimeLog> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var typeResult = await TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

                return new TimeLog(employeeResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    LoginDate = reader.GetNullableDateTime("LoginDate"),
                    LogoutDate = reader.GetNullableDateTime("LogoutDate"),
                    Type = typeResult.Data
                };
            }
            else
            {
                return null;
            }
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
