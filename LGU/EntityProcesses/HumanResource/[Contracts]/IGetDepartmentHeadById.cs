using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentHeadById : IProcess<IDepartmentHead>
    {
        long DepartmentHeadId { get; set; }
    }
}
