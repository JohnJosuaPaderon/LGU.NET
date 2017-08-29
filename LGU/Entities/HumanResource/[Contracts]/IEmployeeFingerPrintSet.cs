using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IEmployeeFingerPrintSet : IFingerPrintSet
    {
        IEmployee Employee { get; }
    }
}
