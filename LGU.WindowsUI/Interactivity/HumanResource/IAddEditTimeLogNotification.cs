using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public interface IAddEditTimeLogNotification : ICustomNotification
    {
        AddEditTimeLogMode Mode { get; }
        TimeLogModel TimeLog { get; set; }
    }
}
