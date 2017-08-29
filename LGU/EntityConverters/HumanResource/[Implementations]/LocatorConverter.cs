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

        private ILocator GetData(IEmployee requestor, ILocatorLeaveType leaveType, SqlDataReader reader)
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

        private ILocator GetData(SqlDataReader reader)
        {
            var requestorResult = r_EmployeeManager.GetById(reader.GetInt64("RequestorId"));
            var leaveTypeResult = r_LocatorLeaveTypeManager.GetById(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<ILocator> GetDataAsync(SqlDataReader reader)
        {
            var requestorResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"));
            var leaveTypeResult = await r_LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<ILocator> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var requestorResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"), cancellationToken);
            var leaveTypeResult = await r_LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"), cancellationToken);

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        public IEnumerableProcessResult<ILocator> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ILocator>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocator>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ILocator>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ILocator>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocator>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ILocator>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ILocator>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocator>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocator>(ex);
            }
        }

        public IProcessResult<ILocator> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ILocator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocator>(ex);
            }
        }

        public async Task<IProcessResult<ILocator>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ILocator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocator>(ex);
            }
        }

        public async Task<IProcessResult<ILocator>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ILocator>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocator>(ex);
            }
        }
    }
}
