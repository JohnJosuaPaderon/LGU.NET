using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogTypeById : IDataProcess<TimeLogType>
    {
        short TimeLogTypeId { get; set; }
    }
}
