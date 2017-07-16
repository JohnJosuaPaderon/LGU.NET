using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertTimeLog : IDataProcess<TimeLog>
    {
        TimeLog TimeLog { get; set; }
    }
}
