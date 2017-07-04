using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentById : IDataProcess<Department>, IAsyncDataProcess<Department>, ICancellableAsyncDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
