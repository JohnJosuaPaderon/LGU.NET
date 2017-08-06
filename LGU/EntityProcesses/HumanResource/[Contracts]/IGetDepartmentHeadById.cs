using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentHeadById : IProcess<DepartmentHead>
    {
        long DepartmentHeadId { get; set; }
    }
}
