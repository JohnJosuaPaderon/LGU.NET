using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteDepartment : IProcess<Department>
    {
        Department Department { get; set; }
    }
}
