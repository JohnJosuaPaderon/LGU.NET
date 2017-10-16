using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class LocatorLeaveTypeConverter : ILocatorLeaveTypeConverter
    {
        private ILocatorLeaveType GetData(DbDataReader reader)
        {
            return new LocatorLeaveType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<ILocatorLeaveType> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<ILocatorLeaveType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocatorLeaveType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ILocatorLeaveType>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<ILocatorLeaveType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocatorLeaveType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ILocatorLeaveType>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ILocatorLeaveType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ILocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ILocatorLeaveType>(ex);
            }
        }

        public IProcessResult<ILocatorLeaveType> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ILocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocatorLeaveType>(ex);
            }
        }

        public async Task<IProcessResult<ILocatorLeaveType>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ILocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocatorLeaveType>(ex);
            }
        }

        public async Task<IProcessResult<ILocatorLeaveType>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ILocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ILocatorLeaveType>(ex);
            }
        }
    }
}
