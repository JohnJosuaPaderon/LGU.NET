using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeFingerPrintSet : IDataProcess<EmployeeFingerPrintSet>, IAsyncDataProcess<EmployeeFingerPrintSet>, ICancellableAsyncDataProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
