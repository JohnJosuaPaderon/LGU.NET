using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateTimeLog : IDataProcess<TimeLog>
    {
        TimeLog TimeLog { get; set; }
    }
}
