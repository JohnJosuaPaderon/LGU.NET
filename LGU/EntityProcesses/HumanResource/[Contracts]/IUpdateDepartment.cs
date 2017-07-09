using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateDepartment : IDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
