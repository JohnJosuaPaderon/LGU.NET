using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartmentHead : IProcess<IDepartmentHead>
    {
        IDepartmentHead DepartmentHead { get; set; }
    }
}
