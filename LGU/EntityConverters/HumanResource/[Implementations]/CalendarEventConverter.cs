using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class CalendarEventConverter : ICalendarEventConverter<SqlDataReader>
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_DATE_OCCUR = "DateOccur";
        private const string FIELD_DATE_OCCUR_END = "DateOccurEnd";
        private const string FIELD_IS_HOLIDAY = "IsHoliday";
        private const string FIELD_IS_NON_WORKING = "IsNonWorking";
        private const string FIELD_IS_ANNUAL = "IsAnnual";

        public CalendarEventConverter()
        {
            Prop_Id = new DataConverterProperty<long>();
            Prop_Description = new DataConverterProperty<string>();
            Prop_DateOccur = new DataConverterProperty<DateTime>();
            Prop_DateOccurEnd = new DataConverterProperty<DateTime?>();
            Prop_IsHoliday = new DataConverterProperty<bool>();
            Prop_IsNonWorking = new DataConverterProperty<bool>();
            Prop_IsAnnual = new DataConverterProperty<bool>();
        }

        public IDataConverterProperty<long> Prop_Id { get; }
        public IDataConverterProperty<string> Prop_Description { get; }
        public IDataConverterProperty<DateTime> Prop_DateOccur { get; }
        public IDataConverterProperty<DateTime?> Prop_DateOccurEnd { get; }
        public IDataConverterProperty<bool> Prop_IsHoliday { get; }
        public IDataConverterProperty<bool> Prop_IsNonWorking { get; }
        public IDataConverterProperty<bool> Prop_IsAnnual { get; }

        private ICalendarEvent Get(SqlDataReader reader)
        {
            return new CalendarEvent
            {
                Id = Prop_Id.TryGetValue(reader.GetInt64, FIELD_ID),
                Description = Prop_Description.TryGetValue(reader.GetString, FIELD_DESCRIPTION),
                DateOccur = Prop_DateOccur.TryGetValue(reader.GetDateTime, FIELD_DATE_OCCUR),
                 DateOccurEnd = Prop_DateOccurEnd.TryGetValue(reader.GetNullableDateTime, FIELD_DATE_OCCUR_END),
                 IsHoliday = Prop_IsHoliday.TryGetValue(reader.GetBoolean, FIELD_IS_HOLIDAY),
                 IsNonWorking = Prop_IsNonWorking.TryGetValue(reader.GetBoolean, FIELD_IS_NON_WORKING),
                 IsAnnual = Prop_IsAnnual.TryGetValue(reader.GetBoolean, FIELD_IS_ANNUAL)
            };
        }

        public IEnumerableProcessResult<ICalendarEvent> EnumerableFromReader(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<ICalendarEvent>> EnumerableFromReaderAsync(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<ICalendarEvent>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<ICalendarEvent> FromReader(SqlDataReader reader)
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

        public async Task<IProcessResult<ICalendarEvent>> FromReaderAsync(SqlDataReader reader)
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

        public async Task<IProcessResult<ICalendarEvent>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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
