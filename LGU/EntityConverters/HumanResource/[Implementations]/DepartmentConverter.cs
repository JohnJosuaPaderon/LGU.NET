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
    public class DepartmentConverter : IDepartmentConverter<SqlDataReader>
    {
        private static Department GetData(SqlDataReader reader)
        {
            return new Department()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                Abbreviation = reader.GetString("Abbreviation")
            };
        }

        public IEnumerableProcessResult<Department> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Department>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Department>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Department>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Department>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Department>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Department>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Department>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Department>(ex);
            }

        }

        public IProcessResult<Department> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Department>(ex);
            }
        }

        public async Task<IProcessResult<Department>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Department>(ex);
            }
        }

        public async Task<IProcessResult<Department>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Department>(ex);
            }
        }
    }
}
