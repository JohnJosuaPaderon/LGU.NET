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
    public sealed class LocatorConverter : ILocatorConverter
    {
        private IEmployeeManager EmployeeManager;
        private ILocatorLeaveTypeManager LocatorLeaveTypeManager;
        
        private ILocator GetData(IEmployee requestor, ILocatorLeaveType leaveType, DbDataReader reader)
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

        private ILocator GetData(DbDataReader reader)
        {
            var requestorResult = EmployeeManager.GetById(reader.GetInt64("RequestorId"));
            var leaveTypeResult = LocatorLeaveTypeManager.GetById(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<ILocator> GetDataAsync(DbDataReader reader)
        {
            var requestorResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"));
            var leaveTypeResult = await LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"));

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        private async Task<ILocator> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var requestorResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("RequestorId"), cancellationToken);
            var leaveTypeResult = await LocatorLeaveTypeManager.GetByIdAsync(reader.GetInt16("LeaveTypeId"), cancellationToken);

            return GetData(requestorResult.Data, leaveTypeResult.Data, reader);
        }

        public IEnumerableProcessResult<ILocator> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<ILocator>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<ILocator>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<ILocator> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<ILocator>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<ILocator>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public void InitializeDependency()
        {
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            LocatorLeaveTypeManager = ApplicationDomain.GetService<ILocatorLeaveTypeManager>();
        }
    }
}
