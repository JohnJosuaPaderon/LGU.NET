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
        private const string FIELD_ID = "Id";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_WORK_TIME_START = "WorkTimeStart";
        private const string FIELD_WORK_TIME_END = "WorkTimeEnd";
        private const string FIELD_BREAK_TIME = "BreakTime";
        private const string FIELD_WORKING_MONTH_DAYS = "WorkingMonthDays";

        public WorkTimeScheduleConverter()
        {
            Prop_Id = new DataConverterProperty<int>();
            Prop_Description = new DataConverterProperty<string>();
            Prop_WorkTimeStart = new DataConverterProperty<DateTime>();
            Prop_WorkTimeEnd = new DataConverterProperty<DateTime>();
            Prop_BreakTime = new DataConverterProperty<TimeSpan?>();
            Prop_WorkingMonthDays = new DataConverterProperty<int>();
        }

        public IDataConverterProperty<int> Prop_Id { get; }
        public IDataConverterProperty<string> Prop_Description { get; }
        public IDataConverterProperty<DateTime> Prop_WorkTimeStart { get; }
        public IDataConverterProperty<DateTime> Prop_WorkTimeEnd { get; }
        public IDataConverterProperty<TimeSpan?> Prop_BreakTime { get; }
        public IDataConverterProperty<int> Prop_WorkingMonthDays { get; }

        private IWorkTimeSchedule GetData(DbDataReader reader)
        {
            return new WorkTimeSchedule()
            {
                Id = Prop_Id.TryGetValue(reader.GetInt32, FIELD_ID),
                Description = Prop_Description.TryGetValue(reader.GetString, FIELD_DESCRIPTION),
                WorkTimeStart = Prop_WorkTimeStart.TryGetValue(reader.GetDateTime, FIELD_WORK_TIME_START),
                WorkTimeEnd = Prop_WorkTimeEnd.TryGetValue(reader.GetDateTime, FIELD_WORK_TIME_END),
                BreakTime = Prop_BreakTime.TryGetValue(reader.GetNullableTimeSpan, FIELD_BREAK_TIME),
                WorkingMonthDays = Prop_WorkingMonthDays.TryGetValue(reader.GetInt32, FIELD_WORKING_MONTH_DAYS)
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
    }
}
