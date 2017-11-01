using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class WorkTimeScheduleConverter : IWorkTimeScheduleConverter
    {
        public WorkTimeScheduleConverter(IWorkTimeScheduleFields fields)
        {
            _Fields = fields;

            PId = new DataConverterProperty<int>();
            PDescription = new DataConverterProperty<string>();
            PWorkTimeStart = new DataConverterProperty<DateTime>();
            PWorkTimeEnd = new DataConverterProperty<DateTime>();
            PBreakTime = new DataConverterProperty<TimeSpan?>();
            PWorkingMonthDays = new DataConverterProperty<int>();
        }

        private readonly IWorkTimeScheduleFields _Fields;

        public IDataConverterProperty<int> PId { get; }
        public IDataConverterProperty<string> PDescription { get; }
        public IDataConverterProperty<DateTime> PWorkTimeStart { get; }
        public IDataConverterProperty<DateTime> PWorkTimeEnd { get; }
        public IDataConverterProperty<TimeSpan?> PBreakTime { get; }
        public IDataConverterProperty<int> PWorkingMonthDays { get; }

        private IWorkTimeSchedule GetData(DbDataReader reader)
        {
            return new WorkTimeSchedule()
            {
                Id = PId.TryGetValue(reader.GetInt32, _Fields.Id),
                Description = PDescription.TryGetValue(reader.GetString, _Fields.Description),
                WorkTimeStart = PWorkTimeStart.TryGetValue(reader.GetDateTime, _Fields.WorkTimeStart),
                WorkTimeEnd = PWorkTimeEnd.TryGetValue(reader.GetDateTime, _Fields.WorkTimeEnd),
                BreakTime = PBreakTime.TryGetValue(reader.GetNullableTimeSpan, _Fields.BreakTime),
                WorkingMonthDays = PWorkingMonthDays.TryGetValue(reader.GetInt32, _Fields.WorkingMonthDays)
            };
        }

        public IEnumerableProcessResult<IWorkTimeSchedule> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IWorkTimeSchedule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IWorkTimeSchedule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public IProcessResult<IWorkTimeSchedule> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IWorkTimeSchedule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IWorkTimeSchedule>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
