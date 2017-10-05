using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
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
    public sealed class EmployeeWorkdayScheduleConverter : IEmployeeWorkdayScheduleConverter<SqlDataReader>
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_EMPLOYEE_ID = "EmployeeId";
        private const string FIELD_SUNDAY = "Sunday";
        private const string FIELD_MONDAY = "Monday";
        private const string FIELD_TUESDAY = "Tuesday";
        private const string FIELD_WEDNESDAY = "Wednesday";
        private const string FIELD_THURSDAY = "Thursday";
        private const string FIELD_FRIDAY = "Friday";
        private const string FIELD_SATURDAY = "Saturday";

        public EmployeeWorkdayScheduleConverter(IEmployeeManager employeeManager)
        {
            _EmployeeManager = employeeManager;

            Prop_Id = new DataConverterProperty<long>();
            Prop_Employee = new DataConverterProperty<IEmployee>();
            Prop_Sunday = new DataConverterProperty<bool>();
            Prop_Monday = new DataConverterProperty<bool>();
            Prop_Tuesday = new DataConverterProperty<bool>();
            Prop_Wednesday = new DataConverterProperty<bool>();
            Prop_Thursday = new DataConverterProperty<bool>();
            Prop_Friday = new DataConverterProperty<bool>();
            Prop_Saturday = new DataConverterProperty<bool>();
        }

        private readonly IEmployeeManager _EmployeeManager;

        public IDataConverterProperty<long> Prop_Id { get; }
        public IDataConverterProperty<IEmployee> Prop_Employee { get; }
        public IDataConverterProperty<bool> Prop_Sunday { get; }
        public IDataConverterProperty<bool> Prop_Monday { get; }
        public IDataConverterProperty<bool> Prop_Tuesday { get; }
        public IDataConverterProperty<bool> Prop_Wednesday { get; }
        public IDataConverterProperty<bool> Prop_Thursday { get; }
        public IDataConverterProperty<bool> Prop_Friday { get; }
        public IDataConverterProperty<bool> Prop_Saturday { get; }

        private IEmployeeWorkdaySchedule Get(IEmployee employee, SqlDataReader reader)
        {
            return new EmployeeWorkdaySchedule
            {
                Id = Prop_Id.TryGetValue(reader.GetInt64, FIELD_ID),
                Employee = employee,
                Sunday = Prop_Sunday.TryGetValue(reader.GetBoolean, FIELD_SUNDAY),
                Monday = Prop_Monday.TryGetValue(reader.GetBoolean, FIELD_MONDAY),
                Tuesday = Prop_Tuesday.TryGetValue(reader.GetBoolean, FIELD_TUESDAY),
                Wednesday = Prop_Wednesday.TryGetValue(reader.GetBoolean, FIELD_WEDNESDAY),
                Thursday = Prop_Thursday.TryGetValue(reader.GetBoolean, FIELD_THURSDAY),
                Friday = Prop_Friday.TryGetValue(reader.GetBoolean, FIELD_FRIDAY),
                Saturday = Prop_Saturday.TryGetValue(reader.GetBoolean, FIELD_SATURDAY)
            };
        }
        
        private IEmployeeWorkdaySchedule Get(SqlDataReader reader)
        {
            var employee = Prop_Employee.TryGetValueFromProcess2(_EmployeeManager.GetById, reader.GetInt64, FIELD_EMPLOYEE_ID);
            return Get(employee, reader);
        }

        private async Task<IEmployeeWorkdaySchedule> GetAsync(SqlDataReader reader)
        {
            var employee = await Prop_Employee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, FIELD_EMPLOYEE_ID);
            return Get(employee, reader);
        }

        private async Task<IEmployeeWorkdaySchedule> GetAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employee = await Prop_Employee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, FIELD_EMPLOYEE_ID, cancellationToken);
            return Get(employee, reader);
        }

        public IEnumerableProcessResult<IEmployeeWorkdaySchedule> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeWorkdaySchedule>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkdaySchedule>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeWorkdaySchedule>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkdaySchedule>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeWorkdaySchedule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }

        public IProcessResult<IEmployeeWorkdaySchedule> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeWorkdaySchedule>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeWorkdaySchedule>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeWorkdaySchedule>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeWorkdaySchedule>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeWorkdaySchedule>(ex);
            }
        }
    }
}
