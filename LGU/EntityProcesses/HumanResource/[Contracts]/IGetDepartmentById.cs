using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentById : IProcess<IDepartment>
    {
        int DepartmentId { get; set; }
    }
}
