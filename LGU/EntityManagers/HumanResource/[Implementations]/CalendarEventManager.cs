using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class CalendarEventManager : EntityManagerBase<ICalendarEvent, long>, ICalendarEventManager
    {
        private const string MESSAGE_INVALID = "Invalid calendar event.";
        private const string MESSAGE_INVALID_IDENTIFIER = "Invalid calendar event identifier.";

        public CalendarEventManager(
            IDeleteCalendarEvent delete,
            IGetCalendarEventById getById,
            IInsertCalendarEvent insert,
            IUpdateCalendarEvent update)
        {
            _Delete = delete;
            _GetById = getById;
            _Insert = insert;
            _Update = update;

            _InvalidResult = new ProcessResult<ICalendarEvent>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _InvalidIdentifierResult = new ProcessResult<ICalendarEvent>(ProcessResultStatus.Failed, MESSAGE_INVALID_IDENTIFIER);
        }

        private readonly IDeleteCalendarEvent _Delete;
        private readonly IGetCalendarEventById _GetById;
        private readonly IInsertCalendarEvent _Insert;
        private readonly IUpdateCalendarEvent _Update;
        private readonly IProcessResult<ICalendarEvent> _InvalidResult;
        private readonly IProcessResult<ICalendarEvent> _InvalidIdentifierResult;

        public IProcessResult<ICalendarEvent> Delete(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Delete.CalendarEvent = calendarEvent;
                return RemoveIfSuccess(_Delete.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> DeleteAsync(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Delete.CalendarEvent = calendarEvent;
                return RemoveIfSuccess(await _Delete.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> DeleteAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken)
        {
            if (calendarEvent != null)
            {
                _Delete.CalendarEvent = calendarEvent;
                return RemoveIfSuccess(await _Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<ICalendarEvent> GetById(long calendarEventId)
        {
            if (calendarEventId > 0)
            {
                if (StaticSource.ContainsId(calendarEventId))
                {
                    return new ProcessResult<ICalendarEvent>(StaticSource[calendarEventId]);
                }
                else
                {
                    _GetById.CalendarEventId = calendarEventId;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> GetByIdAsync(long calendarEventId)
        {
            if (calendarEventId > 0)
            {
                if (StaticSource.ContainsId(calendarEventId))
                {
                    return new ProcessResult<ICalendarEvent>(StaticSource[calendarEventId]);
                }
                else
                {
                    _GetById.CalendarEventId = calendarEventId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> GetByIdAsync(long calendarEventId, CancellationToken cancellationToken)
        {
            if (calendarEventId > 0)
            {
                if (StaticSource.ContainsId(calendarEventId))
                {
                    return new ProcessResult<ICalendarEvent>(StaticSource[calendarEventId]);
                }
                else
                {
                    _GetById.CalendarEventId = calendarEventId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public IProcessResult<ICalendarEvent> Insert(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Insert.CalendarEvent = calendarEvent;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> InsertAsync(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Insert.CalendarEvent = calendarEvent;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> InsertAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken)
        {
            if (calendarEvent != null)
            {
                _Insert.CalendarEvent = calendarEvent;
                return AddIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<ICalendarEvent> Update(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Update.CalendarEvent = calendarEvent;
                return UpdateIfSuccess(_Update.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> UpdateAsync(ICalendarEvent calendarEvent)
        {
            if (calendarEvent != null)
            {
                _Update.CalendarEvent = calendarEvent;
                return UpdateIfSuccess(await _Update.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<ICalendarEvent>> UpdateAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken)
        {
            if (calendarEvent != null)
            {
                _Update.CalendarEvent = calendarEvent;
                return UpdateIfSuccess(await _Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
