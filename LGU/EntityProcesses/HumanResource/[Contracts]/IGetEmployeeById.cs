using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeById : IDataProcess<Employee>
    {
        long EmployeeId { get; set; }
    }
}
