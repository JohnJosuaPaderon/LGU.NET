using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ICalendarEventManager
    {
        IProcessResult<ICalendarEvent> Delete(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> DeleteAsync(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> DeleteAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken);
        IProcessResult<ICalendarEvent> GetById(long calendarEventId);
        Task<IProcessResult<ICalendarEvent>> GetByIdAsync(long calendarEventId);
        Task<IProcessResult<ICalendarEvent>> GetByIdAsync(long calendarEventId, CancellationToken cancellationToken);
        IProcessResult<ICalendarEvent> Insert(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> InsertAsync(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> InsertAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken);
        IProcessResult<ICalendarEvent> Update(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> UpdateAsync(ICalendarEvent calendarEvent);
        Task<IProcessResult<ICalendarEvent>> UpdateAsync(ICalendarEvent calendarEvent, CancellationToken cancellationToken);
        IEnumerableProcessResult<ICalendarEvent> GetList();
        Task<IEnumerableProcessResult<ICalendarEvent>> GetListAsync();
        Task<IEnumerableProcessResult<ICalendarEvent>> GetListAsync(CancellationToken cancellationToken);
    }
}
