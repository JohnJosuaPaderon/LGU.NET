using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentById : IDataProcess<Department>
    {
        int DepartmentId { get; set; }
    }
}
