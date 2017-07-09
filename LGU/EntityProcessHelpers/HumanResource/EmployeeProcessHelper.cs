using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcessHelpers.HumanResource
{
    internal static class EmployeeProcessHelper
    {
        static EmployeeProcessHelper()
        {
            DepartmentManager = SystemRuntime.ServiceProvider.GetService<IDepartmentManager>();
        }

        static readonly IDepartmentManager DepartmentManager;

        private static Employee GetData(SqlDataReader reader)
        {
            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Department = DepartmentManager.GetById(reader.GetInt32("DepartmentId")).Data
            };
        }

        private static async Task<Employee> GetDataAsync(SqlDataReader reader)
        {
            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Department = (await DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"))).Data
            };
        }

        private static async Task<Employee> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Department = (await DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"), cancellationToken)).Data
            };
        }

        public static IEnumerableDataProcessResult<Employee> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Employee>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Employee>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Employee>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Employee>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableDataProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Employee>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Employee>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Employee>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableDataProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Employee>(ex);
            }
        }

        public static IDataProcessResult<Employee> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<Employee>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Employee>(ex);
            }
        }

        public static async Task<IDataProcessResult<Employee>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<Employee>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Employee>(ex);
            }
        }

        public static async Task<IDataProcessResult<Employee>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<Employee>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Employee>(ex);
            }
        }

    }
}
