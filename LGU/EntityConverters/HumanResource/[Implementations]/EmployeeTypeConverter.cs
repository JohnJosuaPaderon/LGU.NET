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
    public sealed class EmployeeTypeConverter : IEmployeeTypeConverter<SqlDataReader>
    {
        private IEmployeeType GetData(SqlDataReader reader)
        {
            return new EmployeeType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IEmployeeType> EnumerableFromReader(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployeeType>> EnumerableFromReaderAsync(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployeeType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IEmployeeType> FromReader(SqlDataReader reader)
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

        public async Task<IProcessResult<IEmployeeType>> FromReaderAsync(SqlDataReader reader)
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

        public async Task<IProcessResult<IEmployeeType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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
