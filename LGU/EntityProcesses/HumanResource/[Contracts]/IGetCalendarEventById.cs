using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetCalendarEventById : IProcess<ICalendarEvent>
    {
        long CalendarEventId { get; set; }
    }
}
