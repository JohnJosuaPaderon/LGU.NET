using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollTypeConverter<TDataReader> : IDataConverter<IPayrollType, TDataReader>
       where TDataReader : DbDataReader
    {
    }
}
