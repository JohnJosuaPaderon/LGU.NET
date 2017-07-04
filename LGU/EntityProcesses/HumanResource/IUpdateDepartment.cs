using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateDepartment : IDataProcess<Department>, IAsyncDataProcess<Department>, ICancellableAsyncDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
