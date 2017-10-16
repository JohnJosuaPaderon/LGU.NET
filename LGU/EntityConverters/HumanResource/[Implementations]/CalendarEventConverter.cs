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
    public sealed class CalendarEventConverter : ICalendarEventConverter
    {
        public CalendarEventConverter(ICalendarEventFields fields)
        {
            _Fields = fields;

            PId = new DataConverterProperty<long>();
            PDescription = new DataConverterProperty<string>();
            PDateOccur = new DataConverterProperty<DateTime>();
            PDateOccurEnd = new DataConverterProperty<DateTime?>();
            PIsHoliday = new DataConverterProperty<bool>();
            PIsNonWorking = new DataConverterProperty<bool>();
            PIsAnnual = new DataConverterProperty<bool>();
        }

        private readonly ICalendarEventFields _Fields;

        public IDataConverterProperty<long> PId { get; }
        public IDataConverterProperty<string> PDescription { get; }
        public IDataConverterProperty<DateTime> PDateOccur { get; }
        public IDataConverterProperty<DateTime?> PDateOccurEnd { get; }
        public IDataConverterProperty<bool> PIsHoliday { get; }
        public IDataConverterProperty<bool> PIsNonWorking { get; }
        public IDataConverterProperty<bool> PIsAnnual { get; }

        private ICalendarEvent Get(DbDataReader reader)
        {
            return new CalendarEvent
            {
                Id = PId.TryGetValue(reader.GetInt64, _Fields.Id),
                Description = PDescription.TryGetValue(reader.GetString, _Fields.Description),
                DateOccur = PDateOccur.TryGetValue(reader.GetDateTime, _Fields.DateOccur),
                DateOccurEnd = PDateOccurEnd.TryGetValue(reader.GetNullableDateTime, _Fields.DateOccurEnd),
                IsHoliday = PIsHoliday.TryGetValue(reader.GetBoolean, _Fields.IsHoliday),
                IsNonWorking = PIsNonWorking.TryGetValue(reader.GetBoolean, _Fields.IsNonWorking),
                IsAnnual = PIsAnnual.TryGetValue(reader.GetBoolean, _Fields.IsAnnual)
            };
        }

        public IEnumerableProcessResult<ICalendarEvent> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<ICalendarEvent>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<ICalendarEvent>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ICalendarEvent>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ICalendarEvent>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<ICalendarEvent>();

                while (await reader.ReadAsync())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<ICalendarEvent>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ICalendarEvent>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ICalendarEvent>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ICalendarEvent>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<ICalendarEvent>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ICalendarEvent>(ex);
            }
        }

        public IProcessResult<ICalendarEvent> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ICalendarEvent>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ICalendarEvent>(ex);
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ICalendarEvent>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ICalendarEvent>(ex);
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ICalendarEvent>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ICalendarEvent>(ex);
            }
        }
    }
}
