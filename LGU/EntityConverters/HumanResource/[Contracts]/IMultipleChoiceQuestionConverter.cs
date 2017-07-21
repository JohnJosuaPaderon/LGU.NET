using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IMultipleChoiceQuestionConverter<TDataReader> : IDataConverter<MultipleChoiceQuestion, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
