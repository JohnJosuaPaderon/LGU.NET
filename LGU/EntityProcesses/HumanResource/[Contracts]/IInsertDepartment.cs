using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartment : IDataProcess<Department>, IAsyncDataProcess<Department>, ICancellableAsyncDataProcess<Department>
    {
        Department Department { get; set; }
    }
}
