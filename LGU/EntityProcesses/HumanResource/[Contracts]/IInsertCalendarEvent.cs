using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertCalendarEvent : IProcess<ICalendarEvent>
    {
        ICalendarEvent CalendarEvent { get; set; }
    }
}
