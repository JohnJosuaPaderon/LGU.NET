using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IMultipleChoiceQuestionConverter<TDataReader> : IDataConverter<IMultipleChoiceQuestion, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
