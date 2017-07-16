using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
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

        public IEnumerableDataProcessResult<TimeLog> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLog>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<TimeLog>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<TimeLog>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableDataProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<TimeLog>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<TimeLog>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableDataProcessResult<TimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<TimeLog>(ex);
            }
        }

        public IDataProcessResult<TimeLog> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<TimeLog>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IDataProcessResult<TimeLog>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<TimeLog>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<TimeLog>(ex);
            }
        }

        public async Task<IDataProcessResult<TimeLog>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<TimeLog>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<TimeLog>(ex);
            }
        }
    }
}
