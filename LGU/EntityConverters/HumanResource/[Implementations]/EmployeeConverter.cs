using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class EmployeeConverter : IEmployeeConverter
    {
        public EmployeeConverter(IEmployeeFields fields)
        {
            _Fields = fields;

            PId = new DataConverterProperty<long>();
            PFirstName = new DataConverterProperty<string>();
            PMiddleName = new DataConverterProperty<string>();
            PLastName = new DataConverterProperty<string>();
            PNameExtension = new DataConverterProperty<string>();
            PBirthDate = new DataConverterProperty<DateTime?>();
            PDeceased = new DataConverterProperty<bool>();
            PMonthlySalary = new DataConverterProperty<decimal>();
            PDepartment = new DataConverterProperty<IDepartment>();
            PEmploymentStatus = new DataConverterProperty<IEmploymentStatus>();
            PGender = new DataConverterProperty<IGender>();
            PPosition = new DataConverterProperty<IPosition>();
            PType = new DataConverterProperty<IEmployeeType>();
            PDepartmentHead = new DataConverterProperty<IEmployee>();
            PWorkTimeSchedule = new DataConverterProperty<IWorkTimeSchedule>();
            PPayrollType = new DataConverterProperty<IPayrollType>();
            PIsFlexWorkSchedule = new DataConverterProperty<bool>();
        }

        private readonly IEmployeeFields _Fields;

        public IDataConverterProperty<long> PId { get; }
        public IDataConverterProperty<string> PFirstName { get; }
        public IDataConverterProperty<string> PMiddleName { get; }
        public IDataConverterProperty<string> PLastName { get; }
        public IDataConverterProperty<string> PNameExtension { get; }
        public IDataConverterProperty<DateTime?> PBirthDate { get; }
        public IDataConverterProperty<bool> PDeceased { get; }
        public IDataConverterProperty<decimal> PMonthlySalary { get; }
        public IDataConverterProperty<IDepartment> PDepartment { get; }
        public IDataConverterProperty<IEmploymentStatus> PEmploymentStatus { get; }
        public IDataConverterProperty<IGender> PGender { get; }
        public IDataConverterProperty<IPosition> PPosition { get; }
        public IDataConverterProperty<IEmployeeType> PType { get; }
        public IDataConverterProperty<IEmployee> PDepartmentHead { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PWorkTimeSchedule { get; }
        public IDataConverterProperty<IPayrollType> PPayrollType { get; }
        public IDataConverterProperty<bool> PIsFlexWorkSchedule { get; }

        private IGenderManager GenderManager;
        private IDepartmentManager DepartmentManager;
        private IEmployeeTypeManager EmployeeTypeManager;
        private IEmploymentStatusManager EmploymentStatusManager;
        private IPositionManager PositionManager;
        private IWorkTimeScheduleManager WorkTimeScheduleManager;
        private IPayrollTypeManager PayrollTypeManager;
        private IEmployeeManager EmployeeManager;

        private IEmployee Get(
            IGender gender,
            IDepartment department,
            IEmployeeType type,
            IEmploymentStatus employmentStatus,
            IPosition position,
            IEmployee departmentHead,
            IWorkTimeSchedule workTimeSchedule,
            IPayrollType payrollType,
            DbDataReader reader)
        {
            return new Employee()
            {
                Id = PId.TryGetValue(reader.GetInt64, _Fields.Id),
                FirstName = PFirstName.TryGetValue(reader.GetString, _Fields.FirstName),
                MiddleName = PMiddleName.TryGetValue(reader.GetString, _Fields.MiddleName),
                LastName = PLastName.TryGetValue(reader.GetString, _Fields.LastName),
                NameExtension = PNameExtension.TryGetValue(reader.GetString, _Fields.NameExtension),
                BirthDate = PBirthDate.TryGetValue(reader.GetNullableDateTime, _Fields.BirthDate),
                Deceased = PDeceased.TryGetValue(reader.GetBoolean, _Fields.Deceased),
                MonthlySalary = PMonthlySalary.TryGetValue(reader.GetDecimal, _Fields.MonthlySalary),
                Department = department,
                EmploymentStatus = employmentStatus,
                Gender = gender,
                Position = position,
                Type = type,
                DepartmentHead = departmentHead,
                WorkTimeSchedule = workTimeSchedule,
                PayrollType = payrollType,
                //IsFlexWorkSchedule = PIsFlexWorkSchedule.TryGetValue(reader.GetBoolean, _Fields.IsFlexWorkSchedule)
            };
        }

        private IEmployee GetData(DbDataReader reader)
        {
            var gender = PGender.TryGetValueFromProcess(GenderManager.GetById, reader.GetInt16, _Fields.GenderId);
            var department = PDepartment.TryGetValueFromProcess(DepartmentManager.GetById, reader.GetInt32, _Fields.DepartmentId);
            var type = PType.TryGetValueFromProcess(EmployeeTypeManager.GetById, reader.GetInt16, _Fields.TypeId);
            var employmentStatus = PEmploymentStatus.TryGetValueFromProcess(EmploymentStatusManager.GetById, reader.GetInt16, _Fields.EmploymentStatusId);
            var position = PPosition.TryGetValueFromProcess(PositionManager.GetById, reader.GetInt32, _Fields.PositionId);
            var departmentHead = PDepartmentHead.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _Fields.DepartmentHeadId);
            var workTimeSchedule = PWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.WorkTimeScheduleId);
            var payrollType = PPayrollType.TryGetValueFromProcess(PayrollTypeManager.GetById, reader.GetInt16, _Fields.PayrollTypeId);

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

        private async Task<IEmployee> GetDataAsync(DbDataReader reader)
        {
            var gender = await PGender.TryGetValueFromProcessAsync(GenderManager.GetByIdAsync, reader.GetInt16, _Fields.GenderId);
            var department = await PDepartment.TryGetValueFromProcessAsync(DepartmentManager.GetByIdAsync, reader.GetInt32, _Fields.DepartmentId);
            var type = await PType.TryGetValueFromProcessAsync(EmployeeTypeManager.GetByIdAsync, reader.GetInt16, _Fields.TypeId);
            var employmentStatus = await PEmploymentStatus.TryGetValueFromProcessAsync(EmploymentStatusManager.GetByIdAsync, reader.GetInt16, _Fields.EmploymentStatusId);
            var position = await PPosition.TryGetValueFromProcessAsync(PositionManager.GetByIdAsync, reader.GetInt32, _Fields.PositionId);
            var departmentHead = await PDepartmentHead.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.DepartmentHeadId);
            var workTimeSchedule = await PWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.WorkTimeScheduleId);
            var payrollType = await PPayrollType.TryGetValueFromProcessAsync(PayrollTypeManager.GetByIdAsync, reader.GetInt16, _Fields.PayrollTypeId);

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

        private async Task<IEmployee> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var gender = await PGender.TryGetValueFromProcessAsync(GenderManager.GetByIdAsync, reader.GetInt16, _Fields.GenderId, cancellationToken);
            var department = await PDepartment.TryGetValueFromProcessAsync(DepartmentManager.GetByIdAsync, reader.GetInt32, _Fields.DepartmentId, cancellationToken);
            var type = await PType.TryGetValueFromProcessAsync(EmployeeTypeManager.GetByIdAsync, reader.GetInt16, _Fields.TypeId, cancellationToken);
            var employmentStatus = await PEmploymentStatus.TryGetValueFromProcessAsync(EmploymentStatusManager.GetByIdAsync, reader.GetInt16, _Fields.EmploymentStatusId, cancellationToken);
            var position = await PPosition.TryGetValueFromProcessAsync(PositionManager.GetByIdAsync, reader.GetInt32, _Fields.PositionId, cancellationToken);
            var departmentHead = await PDepartmentHead.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.DepartmentHeadId, cancellationToken);
            var workTimeSchedule = await PWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.WorkTimeScheduleId, cancellationToken);
            var payrollType = await PPayrollType.TryGetValueFromProcessAsync(PayrollTypeManager.GetByIdAsync, reader.GetInt16, _Fields.PayrollTypeId, cancellationToken);

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

        public IEnumerableProcessResult<IEmployee> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployee>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployee>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IEmployee> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IEmployee>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IEmployee>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public void InitializeDependency()
        {
            GenderManager = ApplicationDomain.GetService<IGenderManager>();
            DepartmentManager = ApplicationDomain.GetService<IDepartmentManager>();
            EmployeeTypeManager = ApplicationDomain.GetService<IEmployeeTypeManager>();
            EmploymentStatusManager = ApplicationDomain.GetService<IEmploymentStatusManager>();
            PositionManager = ApplicationDomain.GetService<IPositionManager>();
            WorkTimeScheduleManager = ApplicationDomain.GetService<IWorkTimeScheduleManager>();
            PayrollTypeManager = ApplicationDomain.GetService<IPayrollTypeManager>();
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
        }
    }
}
