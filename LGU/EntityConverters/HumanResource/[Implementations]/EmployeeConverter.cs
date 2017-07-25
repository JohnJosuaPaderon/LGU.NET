using LGU.Data.Extensions;
using LGU.Entities.Core;
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
        private readonly IGenderManager r_GenderManager;
        private readonly IDepartmentManager r_DepartmentManager;
        private readonly IEmployeeTypeManager r_EmployeeTypeManager;
        private readonly IEmploymentStatusManager r_EmploymentStatusManager;
        private readonly IPositionManager r_PositionManager;

        public EmployeeConverter(
            IGenderManager genderManager,
            IDepartmentManager departmentManager,
            IEmployeeTypeManager employeeTypeManager,
            IEmploymentStatusManager employmentStatusManager,
            IPositionManager positionManager)
        {
            r_GenderManager = genderManager;
            r_DepartmentManager = departmentManager;
            r_EmployeeTypeManager = employeeTypeManager;
            r_EmploymentStatusManager = employmentStatusManager;
            r_PositionManager = positionManager;
        }

        private Employee GetData(Gender gender, Department department/*, EmployeeType type, EmploymentStatus employmentStatus, Position position*/, SqlDataReader reader)
        {
            return new Employee()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased"),
                Department = department,
                //EmploymentStatus = employmentStatus,
                Gender = gender,
                //Position = position,
                //Type = type
            };
        }

        private Employee GetData(SqlDataReader reader)
        {
            var genderResult = r_GenderManager.GetById(reader.GetInt16("GenderId"));
            var departmentResult = r_DepartmentManager.GetById(reader.GetInt32("DepartmentId"));
            //var typeResult = r_EmployeeTypeManager.GetById(reader.GetInt16("TypeId"));
            //var employmentStatusResult = r_EmploymentStatusManager.GetById(reader.GetInt16("EmploymentStatusId"));
            //var positionResult = r_PositionManager.GetById(reader.GetInt16("PositionId"));

            return GetData(genderResult.Data, departmentResult.Data/*, typeResult.Data, employmentStatusResult.Data, positionResult.Data*/, reader);
        }

        private async Task<Employee> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));
            var departmentResult = await r_DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"));
            //var typeResult = await r_EmployeeTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));
            //var employmentStatusResult = await r_EmploymentStatusManager.GetByIdAsync(reader.GetInt16("EmploymentStatusId"));
            //var positionResult = await r_PositionManager.GetByIdAsync(reader.GetInt16("PositionId"));

            return GetData(genderResult.Data, departmentResult.Data/*, typeResult.Data, employmentStatusResult.Data, positionResult.Data*/, reader);
        }

        private async Task<Employee> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);
            var departmentResult = await r_DepartmentManager.GetByIdAsync(reader.GetInt32("DepartmentId"), cancellationToken);
            //var typeResult = await r_EmployeeTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);
            //var employmentStatusResult = await r_EmploymentStatusManager.GetByIdAsync(reader.GetInt16("EmploymentStatusId"), cancellationToken);
            //var positionResult = await r_PositionManager.GetByIdAsync(reader.GetInt16("PositionId"), cancellationToken);

            return GetData(genderResult.Data, departmentResult.Data/*, typeResult.Data, employmentStatusResult.Data, positionResult.Data*/, reader);
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
