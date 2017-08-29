using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IMultipleChoiceCandidateAnswerConverter<TDataReader> : IDataConverter<IMultipleChoiceCandidateAnswer, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
