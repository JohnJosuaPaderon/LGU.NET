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
    public sealed class EmployeeTypeConverter : IEmployeeTypeConverter
    {
        private IEmployeeType GetData(DbDataReader reader)
        {
            return new EmployeeType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IEmployeeType> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeType>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeType>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeType>(ex);
            }
        }

        public IProcessResult<IEmployeeType> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeType>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeType>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeType>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeType>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeType>(ex);
            }
        }
    }
}
