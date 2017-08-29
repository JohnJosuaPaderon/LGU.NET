using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IExamSetConverter<TDataReader> : IDataConverter<IExamSet, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
