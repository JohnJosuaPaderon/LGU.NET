using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteDepartmentHead : IProcess<DepartmentHead>
    {
        DepartmentHead DepartmentHead { get; set; }
    }
}
