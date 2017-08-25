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
    public sealed class LocatorConverter : ILocatorConverter<SqlDataReader>
    {
        private readonly IEmployeeManager r_EmployeeManager;
        private readonly ILocatorLeaveTypeManager r_LocatorLeaveTypeManager;

        public LocatorConverter(
            IEmployeeManager employeeManager,
            ILocatorLeaveTypeManager locatorLeaveTypeManager)
        {
            r_EmployeeManager = employeeManager;
            r_LocatorLeaveTypeManager = locatorLeaveTypeManager;
        }

        private Locator GetData(Employee requestor, LocatorLeaveType leaveType, SqlDataReader reader)
        {
            return new Locator(requestor)
            {
                Id = reader.GetInt64("Id"),
                OfficeOutTime = reader.GetDateTime("OfficeOutTime"),
                ExpectedReturnTime = reader.GetNullableDateTime("ExpectedReturnTime"),
                LeaveType = leaveType,
                Purpose = reader.GetString("Purpose"),
                Date = reader.GetDateTime("Date"),
                DepartmentHead = reader.GetString("DepartmentHead")
            };
        }

        private Locator GetData(SqlDataReader reader)
        {
            var requestorResult = r_EmployeeManager.GetById(reader.GetInt64("RequestorId"));
            var leaveTypeResult = r_LocatorLeaveTypeManager.GetById(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<Locator> GetDataAsync(SqlDataReader reader)
        {
            var requestorResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"));
            var leaveTypeResult = await r_LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<Locator> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var requestorResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"), cancellationToken);
            var leaveTypeResult = await r_LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"), cancellationToken);

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        public IEnumerableProcessResult<Locator> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Locator>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Locator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Locator>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Locator>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Locator>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Locator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Locator>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Locator>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Locator>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Locator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Locator>(ex);
            }
        }

        public IProcessResult<Locator> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Locator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Locator>(ex);
            }
        }

        public async Task<IProcessResult<Locator>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Locator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Locator>(ex);
            }
        }

        public async Task<IProcessResult<Locator>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Locator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Locator>(ex);
            }
        }
    }
}
