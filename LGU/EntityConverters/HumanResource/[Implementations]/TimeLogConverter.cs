using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class TimeLogConverter : ITimeLogConverter
    {
        private IEmployeeManager EmployeeManager;
        private ITimeLogTypeManager TimeLogTypeManager;

        private ITimeLog GetData(IEmployee employee, ITimeLogType type, DbDataReader reader)
        {
            if (employee != null)
            {
                return new TimeLog(employee)
                {
                    Id = reader.GetInt64("Id"),
                    LoginDate = reader.GetNullableDateTime("LoginDate"),
                    LogoutDate = reader.GetNullableDateTime("LogoutDate"),
                    Type = type
                };
            }
            else
            {
                return null;
            }
        }

        private ITimeLog GetData(DbDataReader reader)
        {
            var employeeResult = EmployeeManager.GetById(reader.GetInt64("EmployeeId"));
            var typeResult = TimeLogTypeManager.GetById(reader.GetInt16("TypeId"));

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        private async Task<ITimeLog> GetDataAsync(DbDataReader reader)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));
            var typeResult = await TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        private async Task<ITimeLog> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);
            var typeResult = await TimeLogTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

            return GetData(employeeResult.Data, typeResult.Data, reader);
        }

        public IEnumerableProcessResult<ITimeLog> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<ITimeLog>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ITimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLog>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ITimeLog>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<ITimeLog>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<ITimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLog>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ITimeLog>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ITimeLog>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<ITimeLog>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ITimeLog>(ex);
            }
        }

        public IProcessResult<ITimeLog> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ITimeLog>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLog>(ex);
            }
        }

        public async Task<IProcessResult<ITimeLog>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ITimeLog>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLog>(ex);
            }
        }

        public async Task<IProcessResult<ITimeLog>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ITimeLog>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ITimeLog>(ex);
            }
        }

        public void InitializeDependency()
        {
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            TimeLogTypeManager = ApplicationDomain.GetService<ITimeLogTypeManager>();
        }
    }
}
