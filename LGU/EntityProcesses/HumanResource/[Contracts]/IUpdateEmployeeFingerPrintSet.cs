using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployeeFingerPrintSet : IDataProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
