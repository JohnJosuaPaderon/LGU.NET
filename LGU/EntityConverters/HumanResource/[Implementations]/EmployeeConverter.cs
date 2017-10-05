using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
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
        private const string FIELD_ID = "Id";
        private const string FIELD_FIRST_NAME = "FirstName";
        private const string FIELD_MIDDLE_NAME = "MiddleName";
        private const string FIELD_LAST_NAME = "LastName";
        private const string FIELD_NAME_EXTENSION = "NameExtension";
        private const string FIELD_BIRTH_DATE = "BirthDate";
        private const string FIELD_DECEASED = "Deceased";
        private const string FIELD_MONTHLY_SALARY = "MonthlySalary";
        private const string FIELD_DEPARTMENT_ID = "DepartmentId";
        private const string FIELD_EMPLOYMENT_STATUS_ID = "EmploymentStatusId";
        private const string FIELD_GENDER_ID = "GenderId";
        private const string FIELD_POSITION_ID = "PositionId";
        private const string FIELD_TYPE_ID = "TypeId";
        private const string FIELD_DEPARTMENT_HEAD_ID = "DepartmentHeadId";
        private const string FIELD_WORK_TIME_SCHEDULE_ID = "WorkTimeScheduleId";
        private const string FIELD_PAYROLL_TYPE_ID = "PayrollTypeId";

        public EmployeeConverter(
            IGenderManager genderManager,
            IDepartmentManager departmentManager,
            IEmployeeTypeManager employeeTypeManager,
            IEmploymentStatusManager employmentStatusManager,
            IPositionManager positionManager,
            IDepartmentHeadManager departmentHeadManager,
            IWorkTimeScheduleManager workTimeScheduleManager,
            IPayrollTypeManager payrollTypeManager)
        {
            _GenderManager = genderManager;
            _DepartmentManager = departmentManager;
            _EmployeeTypeManager = employeeTypeManager;
            _EmploymentStatusManager = employmentStatusManager;
            _PositionManager = positionManager;
            _DepartmentHeadManager = departmentHeadManager;
            _WorkTimeScheduleManager = workTimeScheduleManager;
            _PayrollTypeManager = payrollTypeManager;

            Prop_Id = new DataConverterProperty<long>();
            Prop_FirstName = new DataConverterProperty<string>();
            Prop_MiddleName = new DataConverterProperty<string>();
            Prop_LastName = new DataConverterProperty<string>();
            Prop_NameExtension = new DataConverterProperty<string>();
            Prop_BirthDate = new DataConverterProperty<DateTime?>();
            Prop_Deceased = new DataConverterProperty<bool>();
            Prop_MonthlySalary = new DataConverterProperty<decimal>();
            Prop_Department = new DataConverterProperty<IDepartment>();
            Prop_EmploymentStatus = new DataConverterProperty<IEmploymentStatus>();
            Prop_Gender = new DataConverterProperty<IGender>();
            Prop_Position = new DataConverterProperty<IPosition>();
            Prop_Type = new DataConverterProperty<IEmployeeType>();
            Prop_DepartmentHead = new DataConverterProperty<IDepartmentHead>();
            Prop_WorkTimeSchedule = new DataConverterProperty<IWorkTimeSchedule>();
            Prop_PayrollType = new DataConverterProperty<IPayrollType>();
        }

        public IDataConverterProperty<long> Prop_Id { get; }
        public IDataConverterProperty<string> Prop_FirstName { get; }
        public IDataConverterProperty<string> Prop_MiddleName { get; }
        public IDataConverterProperty<string> Prop_LastName { get; }
        public IDataConverterProperty<string> Prop_NameExtension { get; }
        public IDataConverterProperty<DateTime?> Prop_BirthDate { get; }
        public IDataConverterProperty<bool> Prop_Deceased { get; }
        public IDataConverterProperty<decimal> Prop_MonthlySalary { get; }
        public IDataConverterProperty<IDepartment> Prop_Department { get; }
        public IDataConverterProperty<IEmploymentStatus> Prop_EmploymentStatus { get; }
        public IDataConverterProperty<IGender> Prop_Gender { get; }
        public IDataConverterProperty<IPosition> Prop_Position { get; }
        public IDataConverterProperty<IEmployeeType> Prop_Type { get; }
        public IDataConverterProperty<IDepartmentHead> Prop_DepartmentHead { get; }
        public IDataConverterProperty<IWorkTimeSchedule> Prop_WorkTimeSchedule { get; }
        public IDataConverterProperty<IPayrollType> Prop_PayrollType { get; }

        private readonly IGenderManager _GenderManager;
        private readonly IDepartmentManager _DepartmentManager;
        private readonly IEmployeeTypeManager _EmployeeTypeManager;
        private readonly IEmploymentStatusManager _EmploymentStatusManager;
        private readonly IPositionManager _PositionManager;
        private readonly IDepartmentHeadManager _DepartmentHeadManager;
        private readonly IWorkTimeScheduleManager _WorkTimeScheduleManager;
        private readonly IPayrollTypeManager _PayrollTypeManager;

        private IEmployee Get(
            IGender gender,
            IDepartment department,
            IEmployeeType type,
            IEmploymentStatus employmentStatus,
            IPosition position,
            IDepartmentHead departmentHead,
            IWorkTimeSchedule workTimeSchedule,
            IPayrollType payrollType,
            SqlDataReader reader)
        {
            return new Employee()
            {
                Id = Prop_Id.TryGetValue(reader.GetInt64, FIELD_ID),
                FirstName = Prop_FirstName.TryGetValue(reader.GetString, FIELD_FIRST_NAME),
                MiddleName = Prop_MiddleName.TryGetValue(reader.GetString, FIELD_MIDDLE_NAME),
                LastName = Prop_LastName.TryGetValue(reader.GetString, FIELD_LAST_NAME),
                NameExtension = Prop_NameExtension.TryGetValue(reader.GetString, FIELD_NAME_EXTENSION),
                BirthDate = Prop_BirthDate.TryGetValue(reader.GetNullableDateTime, FIELD_BIRTH_DATE),
                Deceased = Prop_Deceased.TryGetValue(reader.GetBoolean, FIELD_DECEASED),
                MonthlySalary = Prop_MonthlySalary.TryGetValue(reader.GetDecimal, FIELD_MONTHLY_SALARY),
                Department = department,
                EmploymentStatus = employmentStatus,
                Gender = gender,
                Position = position,
                Type = type,
                DepartmentHead = departmentHead,
                WorkTimeSchedule = workTimeSchedule,
                PayrollType = payrollType
            };
        }

        private IEmployee GetData(SqlDataReader reader)
        {
            var gender = Prop_Gender.TryGetValueFromProcess2(_GenderManager.GetById, reader.GetInt16, FIELD_GENDER_ID);
            var department = Prop_Department.TryGetValueFromProcess2(_DepartmentManager.GetById, reader.GetInt32, FIELD_DEPARTMENT_ID);
            var type = Prop_Type.TryGetValueFromProcess2(_EmployeeTypeManager.GetById, reader.GetInt16, FIELD_TYPE_ID);
            var employmentStatus = Prop_EmploymentStatus.TryGetValueFromProcess2(_EmploymentStatusManager.GetById, reader.GetInt16, FIELD_EMPLOYMENT_STATUS_ID);
            var position = Prop_Position.TryGetValueFromProcess2(_PositionManager.GetById, reader.GetInt32, FIELD_POSITION_ID);
            var departmentHead = Prop_DepartmentHead.TryGetValueFromProcess2(_DepartmentHeadManager.GetById, reader.GetInt64, FIELD_DEPARTMENT_HEAD_ID);
            var workTimeSchedule = Prop_WorkTimeSchedule.TryGetValueFromProcess2(_WorkTimeScheduleManager.GetById, reader.GetInt32, FIELD_WORK_TIME_SCHEDULE_ID);
            var payrollType = Prop_PayrollType.TryGetValueFromProcess2(_PayrollTypeManager.GetById, reader.GetInt16, FIELD_PAYROLL_TYPE_ID);

            return Get(
                gender,
                department,
                type,
                employmentStatus,
                position,
                departmentHead,
                workTimeSchedule,
                payrollType,
                reader);
        }

        private async Task<IEmployee> GetDataAsync(SqlDataReader reader)
        {
            var gender = await Prop_Gender.TryGetValueFromProcessAsync(_GenderManager.GetByIdAsync, reader.GetInt16, FIELD_GENDER_ID);
            var department = await Prop_Department.TryGetValueFromProcessAsync(_DepartmentManager.GetByIdAsync, reader.GetInt32, FIELD_DEPARTMENT_ID);
            var type = await Prop_Type.TryGetValueFromProcessAsync(_EmployeeTypeManager.GetByIdAsync, reader.GetInt16, FIELD_TYPE_ID);
            var employmentStatus = await Prop_EmploymentStatus.TryGetValueFromProcessAsync(_EmploymentStatusManager.GetByIdAsync, reader.GetInt16, FIELD_EMPLOYMENT_STATUS_ID);
            var position = await Prop_Position.TryGetValueFromProcessAsync(_PositionManager.GetByIdAsync, reader.GetInt32, FIELD_POSITION_ID);
            var departmentHead = await Prop_DepartmentHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, FIELD_DEPARTMENT_HEAD_ID);
            var workTimeSchedule = await Prop_WorkTimeSchedule.TryGetValueFromProcessAsync(_WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, FIELD_WORK_TIME_SCHEDULE_ID);
            var payrollType = await Prop_PayrollType.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16, FIELD_PAYROLL_TYPE_ID);

            return Get(
                gender,
                department,
                type,
                employmentStatus,
                position,
                departmentHead,
                workTimeSchedule,
                payrollType,
                reader);
        }

        private async Task<IEmployee> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var gender = await Prop_Gender.TryGetValueFromProcessAsync(_GenderManager.GetByIdAsync, reader.GetInt16, FIELD_GENDER_ID, cancellationToken);
            var department = await Prop_Department.TryGetValueFromProcessAsync(_DepartmentManager.GetByIdAsync, reader.GetInt32, FIELD_DEPARTMENT_ID, cancellationToken);
            var type = await Prop_Type.TryGetValueFromProcessAsync(_EmployeeTypeManager.GetByIdAsync, reader.GetInt16, FIELD_TYPE_ID, cancellationToken);
            var employmentStatus = await Prop_EmploymentStatus.TryGetValueFromProcessAsync(_EmploymentStatusManager.GetByIdAsync, reader.GetInt16, FIELD_EMPLOYMENT_STATUS_ID, cancellationToken);
            var position = await Prop_Position.TryGetValueFromProcessAsync(_PositionManager.GetByIdAsync, reader.GetInt32, FIELD_POSITION_ID, cancellationToken);
            var departmentHead = await Prop_DepartmentHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, FIELD_DEPARTMENT_HEAD_ID, cancellationToken);
            var workTimeSchedule = await Prop_WorkTimeSchedule.TryGetValueFromProcessAsync(_WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, FIELD_WORK_TIME_SCHEDULE_ID, cancellationToken);
            var payrollType = await Prop_PayrollType.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16, FIELD_PAYROLL_TYPE_ID, cancellationToken);

            return Get(
                gender,
                department,
                type,
                employmentStatus,
                position,
                departmentHead,
                workTimeSchedule,
                payrollType,
                reader);
        }

        public IEnumerableProcessResult<IEmployee> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployee>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployee>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployee>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployee>(ex);
            }
        }

        public IProcessResult<IEmployee> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployee>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployee>(ex);
            }
        }

        public async Task<IProcessResult<IEmployee>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployee>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployee>(ex);
            }
        }

        public async Task<IProcessResult<IEmployee>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployee>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployee>(ex);
            }
        }
    }
}
