using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployee : IDataProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
