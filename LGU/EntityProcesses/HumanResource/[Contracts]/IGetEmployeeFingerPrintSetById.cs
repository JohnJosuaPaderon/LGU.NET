using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFingerPrintSetById : IDataProcess<EmployeeFingerPrintSet>
    {
        Employee Employee { get; set; }
    }
}
