using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartmentHead : IProcess<DepartmentHead>
    {
        DepartmentHead DepartmentHead { get; set; }
    }
}
