using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployee : IDataProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
