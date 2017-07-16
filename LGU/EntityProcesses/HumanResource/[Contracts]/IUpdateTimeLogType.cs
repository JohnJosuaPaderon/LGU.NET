using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateTimeLogType : IDataProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
