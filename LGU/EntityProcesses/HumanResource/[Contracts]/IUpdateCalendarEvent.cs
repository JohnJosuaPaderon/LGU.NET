using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateCalendarEvent : IProcess<ICalendarEvent>
    {
        ICalendarEvent CalendarEvent { get; set; }
    }
}
