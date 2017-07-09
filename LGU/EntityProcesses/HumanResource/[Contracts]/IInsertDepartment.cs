using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartment : IDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
