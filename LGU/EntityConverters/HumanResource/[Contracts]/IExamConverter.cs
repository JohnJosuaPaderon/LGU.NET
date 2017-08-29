using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IExamConverter<TDataReader> : IDataConverter<IExam, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
