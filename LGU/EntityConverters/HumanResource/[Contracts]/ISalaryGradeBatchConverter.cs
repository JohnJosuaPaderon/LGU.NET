using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ISalaryGradeBatchConverter<TDataReader> : IDataConverter<ISalaryGradeBatch, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
