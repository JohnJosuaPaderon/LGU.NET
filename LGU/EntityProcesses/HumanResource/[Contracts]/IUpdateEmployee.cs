using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployee : IDataProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
