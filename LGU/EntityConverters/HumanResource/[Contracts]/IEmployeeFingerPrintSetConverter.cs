using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeFingerPrintSetConverter<TDataReader> : IDataConverter<EmployeeFingerPrintSet, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
