using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IExamMultipleChoiceAnswerConverter<TDataReader> : IDataConverter<IExamMultipleChoiceAnswer, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
