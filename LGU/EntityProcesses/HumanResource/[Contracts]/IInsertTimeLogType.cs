using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertTimeLogType : IDataProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
