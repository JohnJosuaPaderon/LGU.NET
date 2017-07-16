using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogById : IDataProcess<TimeLog>
    {
        long TimeLogId { get; set; }
    }
}
