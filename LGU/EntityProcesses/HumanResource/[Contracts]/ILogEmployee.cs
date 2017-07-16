using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ILogEmployee : IDataProcess<TimeLog>
    {
        Employee Employee { get; set; }
    }
}
