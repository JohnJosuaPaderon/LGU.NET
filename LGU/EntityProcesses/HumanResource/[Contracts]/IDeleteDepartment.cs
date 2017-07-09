using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteDepartment : IDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
