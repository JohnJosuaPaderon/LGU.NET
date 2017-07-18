using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class EmployeeConverter : IEmployeeConverter<SqlDataReader>
    {
        private readonly IGenderManager GenderManager;
        private readonly IDepartmentManager DepartmentManager;

        public EmployeeConverter(IGenderManager genderManager, IDepartmentManager departmentManager)
        {
            GenderManager = genderManager;
            DepartmentManager = departmentManager;
        }

        private Employee GetData(SqlDataReader reader)
        {
            var genderResult = GenderManager.GetById(reader.GetInt16("GenderId"));
            var departmentResult = DepartmentManager.GetById(reader.GetInt32("DepartmentId"));

            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased"),
                Gender = genderResult.Data,
                Department = departmentResult.Data
            };
        }

        private async Task<Employee> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));
            var departmentResult = await DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"));

            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased"),
                Gender = genderResult.Data,
                Department = departmentResult.Data
            };
        }

        private async Task<Employee> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);
            var departmentResult = await DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"), cancellationToken);

            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased"),
                Gender = genderResult.Data,
                Department = departmentResult.Data
            };
        }

        public IEnumerableProcessResult<Employee> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Employee>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Employee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Employee>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Employee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Employee>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<Employee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Employee>(ex);
            }
        }

        public IProcessResult<Employee> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Employee>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Employee>(ex);
            }
        }

        public async Task<IProcessResult<Employee>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Employee>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Employee>(ex);
            }
        }

        public async Task<IProcessResult<Employee>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Employee>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Employee>(ex);
            }
        }
    }
}
