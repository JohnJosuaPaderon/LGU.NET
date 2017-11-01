using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class EmployeeFlexWorkScheduleConverter : IEmployeeFlexWorkScheduleConverter
    {
        public EmployeeFlexWorkScheduleConverter(IEmployeeFlexWorkScheduleFields fields)
        {
            _Fields = fields;
        }

        private readonly IEmployeeFlexWorkScheduleFields _Fields;

        public IDataConverterProperty<long> PId { get; }
        public IDataConverterProperty<IEmployee> PEmployee { get; }
        public IDataConverterProperty<DateTime> PEffectivityDateBegin { get; }
        public IDataConverterProperty<DateTime> PEffectivityDateEnd { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PSundayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PMondayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PTuesdayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PWednesdayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PThursdayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PFridayWorkTimeSchedule { get; }
        public IDataConverterProperty<IWorkTimeSchedule> PSaturdayWorkTimeSchedule { get; }

        private IEmployeeManager EmployeeManager;
        private IWorkTimeScheduleManager WorkTimeScheduleManager;

        private IEmployeeFlexWorkSchedule Get(
            IEmployee employee,
            IWorkTimeSchedule sundayWorkTimeSchedule,
            IWorkTimeSchedule mondayWorkTimeSchedule,
            IWorkTimeSchedule tuesdayWorkTimeSchedule,
            IWorkTimeSchedule wednesdayWorkTimeSchedule,
            IWorkTimeSchedule thursdayWorkTimeSchedule,
            IWorkTimeSchedule fridayWorkTimeSchedule,
            IWorkTimeSchedule saturdayWorkTimeSchedule,
            DbDataReader reader)
        {
            return new EmployeeFlexWorkSchedule
            {
                Id = PId.TryGetValue(reader.GetInt64, _Fields.Id),
                Employee = employee,
                EffectivityDate = new ValueRange<DateTime>
                (
                    PEffectivityDateBegin.TryGetValue(reader.GetDateTime, _Fields.EffectivityDateBegin),
                    PEffectivityDateEnd.TryGetValue(reader.GetDateTime, _Fields.EffectivityDateEnd)
                ),
                SundayWorkTimeSchedule = sundayWorkTimeSchedule,
                MondayWorkTimeSchedule = mondayWorkTimeSchedule,
                TuesdayWorkTimeSchedule = tuesdayWorkTimeSchedule,
                WednesdayWorkTimeSchedule = wednesdayWorkTimeSchedule,
                ThursdayWorkTimeSchedule = thursdayWorkTimeSchedule,
                FridayWorkTimeSchedule = fridayWorkTimeSchedule,
                SaturdayWorkTimeSchedule = saturdayWorkTimeSchedule

            };
        }

        private IEmployeeFlexWorkSchedule Get(DbDataReader reader)
        {
            var employee = PEmployee.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _Fields.EmployeeId);
            var sundayWorkTimeSchedule = PSundayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.SundayWorkTimeScheduleId);
            var mondayWorkTimeSchedule = PMondayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.MondayWorkTimeScheduleId);
            var tuesdayWorkTimeSchedule = PTuesdayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.TuesdayWorkTimeScheduleId);
            var wednesdayWorkTimeSchedule = PWednesdayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.WednesdayWorkTimeScheduleId);
            var thursdayWorkTimeSchedule = PThursdayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.ThursdayWorkTimeScheduleId);
            var fridayWorkTimeSchedule = PFridayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.FridayWorkTimeScheduleId);
            var saturdayWorkTimeSchedule = PSaturdayWorkTimeSchedule.TryGetValueFromProcess(WorkTimeScheduleManager.GetById, reader.GetInt32, _Fields.SaturdayWorkTimeScheduleId);

            return Get(
                employee,
                sundayWorkTimeSchedule,
                mondayWorkTimeSchedule,
                tuesdayWorkTimeSchedule,
                wednesdayWorkTimeSchedule,
                thursdayWorkTimeSchedule,
                fridayWorkTimeSchedule,
                saturdayWorkTimeSchedule,
                reader);
        }

        private async Task<IEmployeeFlexWorkSchedule> GetAsync(DbDataReader reader)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId);
            var sundayWorkTimeSchedule = await PSundayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.SundayWorkTimeScheduleId);
            var mondayWorkTimeSchedule = await PMondayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.MondayWorkTimeScheduleId);
            var tuesdayWorkTimeSchedule = await PTuesdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.TuesdayWorkTimeScheduleId);
            var wednesdayWorkTimeSchedule = await PWednesdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.WednesdayWorkTimeScheduleId);
            var thursdayWorkTimeSchedule = await PThursdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.ThursdayWorkTimeScheduleId);
            var fridayWorkTimeSchedule = await PFridayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.FridayWorkTimeScheduleId);
            var saturdayWorkTimeSchedule = await PSaturdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.SaturdayWorkTimeScheduleId);

            return Get(
                employee,
                sundayWorkTimeSchedule,
                mondayWorkTimeSchedule,
                tuesdayWorkTimeSchedule,
                wednesdayWorkTimeSchedule,
                thursdayWorkTimeSchedule,
                fridayWorkTimeSchedule,
                saturdayWorkTimeSchedule,
                reader);
        }

        private async Task<IEmployeeFlexWorkSchedule> GetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId, cancellationToken);
            var sundayWorkTimeSchedule = await PSundayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.SundayWorkTimeScheduleId, cancellationToken);
            var mondayWorkTimeSchedule = await PMondayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.MondayWorkTimeScheduleId, cancellationToken);
            var tuesdayWorkTimeSchedule = await PTuesdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.TuesdayWorkTimeScheduleId, cancellationToken);
            var wednesdayWorkTimeSchedule = await PWednesdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.WednesdayWorkTimeScheduleId, cancellationToken);
            var thursdayWorkTimeSchedule = await PThursdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.ThursdayWorkTimeScheduleId, cancellationToken);
            var fridayWorkTimeSchedule = await PFridayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.FridayWorkTimeScheduleId, cancellationToken);
            var saturdayWorkTimeSchedule = await PSaturdayWorkTimeSchedule.TryGetValueFromProcessAsync(WorkTimeScheduleManager.GetByIdAsync, reader.GetInt32, _Fields.SaturdayWorkTimeScheduleId, cancellationToken);

            return Get(
                employee,
                sundayWorkTimeSchedule,
                mondayWorkTimeSchedule,
                tuesdayWorkTimeSchedule,
                wednesdayWorkTimeSchedule,
                thursdayWorkTimeSchedule,
                fridayWorkTimeSchedule,
                saturdayWorkTimeSchedule,
                reader);
        }

        public IEnumerableProcessResult<IEmployeeFlexWorkSchedule> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeFlexWorkSchedule>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeFlexWorkSchedule>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeFlexWorkSchedule>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeFlexWorkSchedule>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeFlexWorkSchedule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public IProcessResult<IEmployeeFlexWorkSchedule> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeFlexWorkSchedule>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeFlexWorkSchedule>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeFlexWorkSchedule>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeFlexWorkSchedule>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeFlexWorkSchedule>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFlexWorkSchedule>(ex);
            }
        }

        public void InitializeDependency()
        {
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            WorkTimeScheduleManager = ApplicationDomain.GetService<IWorkTimeScheduleManager>();
        }
    }
}
