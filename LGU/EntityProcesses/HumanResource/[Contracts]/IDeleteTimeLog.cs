using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteTimeLog : IDataProcess<TimeLog>
    {
        TimeLog TimeLog { get; set; }
    }
}
