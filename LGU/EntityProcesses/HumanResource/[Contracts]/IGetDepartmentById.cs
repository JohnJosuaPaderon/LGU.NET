using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentById : IDataProcess<Department>, IAsyncDataProcess<Department>, ICancellableAsyncDataProcess<Department>
    {
        uint DepartmentId { get; set; }
    }
}
