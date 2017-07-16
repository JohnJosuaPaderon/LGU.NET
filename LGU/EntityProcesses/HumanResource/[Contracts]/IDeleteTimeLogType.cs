using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteTimeLogType : IDataProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
