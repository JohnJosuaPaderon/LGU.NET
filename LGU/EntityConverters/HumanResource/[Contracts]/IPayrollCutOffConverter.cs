using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollCutOffConverter<TDataReader> : IDataConverter<IPayrollCutOff, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
