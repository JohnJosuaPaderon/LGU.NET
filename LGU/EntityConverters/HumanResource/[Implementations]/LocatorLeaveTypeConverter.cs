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
    public sealed class LocatorLeaveTypeConverter : ILocatorLeaveTypeConverter<SqlDataReader>
    {
        private LocatorLeaveType GetData(SqlDataReader reader)
        {
            return new LocatorLeaveType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<LocatorLeaveType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<LocatorLeaveType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<LocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<LocatorLeaveType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<LocatorLeaveType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<LocatorLeaveType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<LocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<LocatorLeaveType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<LocatorLeaveType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<LocatorLeaveType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<LocatorLeaveType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<LocatorLeaveType>(ex);
            }
        }

        public IProcessResult<LocatorLeaveType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<LocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<LocatorLeaveType>(ex);
            }
        }

        public async Task<IProcessResult<LocatorLeaveType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<LocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<LocatorLeaveType>(ex);
            }
        }

        public async Task<IProcessResult<LocatorLeaveType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<LocatorLeaveType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<LocatorLeaveType>(ex);
            }
        }
    }
}
