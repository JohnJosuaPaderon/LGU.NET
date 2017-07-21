using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IExamMultipleChoiceAnswerConverter<TDataReader> : IDataConverter<ExamMultipleChoiceAnswer, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
