using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeById : IDataProcess<Employee>, IAsyncDataProcess<Employee>, ICancellableAsyncDataProcess<Employee>
    {
        ulong EmployeeId { get; set; }
    }
}
