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
        private EmployeeType GetData(SqlDataReader reader)
        {
            return new EmployeeType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<EmployeeType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmployeeType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmployeeType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EmployeeType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmployeeType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmployeeType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EmployeeType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<EmployeeType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EmployeeType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EmployeeType>(ex);
            }
        }

        public IProcessResult<EmployeeType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<EmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmployeeType>(ex);
            }
        }

        public async Task<IProcessResult<EmployeeType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<EmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmployeeType>(ex);
            }
        }

        public async Task<IProcessResult<EmployeeType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<EmployeeType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EmployeeType>(ex);
            }
        }
    }
}
