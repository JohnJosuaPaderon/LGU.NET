using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcessHelpers.HumanResource
{
    internal static class DepartmentProcessHelper
    {
        private static Department GetData(SqlDataReader reader)
        {
            return new Department()
            {
                Id = reader.GetUInt32("Id"),
                Description = reader.GetString("Description"),
                Abbreviation = reader.GetString("Abbreviation")
            };
        }

        public static IEnumerableDataProcessResult<Department> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Department>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new EnumerableDataProcessResult<Department>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Department>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Department>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new EnumerableDataProcessResult<Department>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Department>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Department>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Department>(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new EnumerableDataProcessResult<Department>(ex);
            }

        }

        public static IDataProcessResult<Department> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new DataProcessResult<Department>(ex);
            }
        }

        public static async Task<IDataProcessResult<Department>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new DataProcessResult<Department>(ex);
            }
        }

        public static async Task<IDataProcessResult<Department>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<Department>(GetData(reader));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new DataProcessResult<Department>(ex);
            }
        }
    }
}
