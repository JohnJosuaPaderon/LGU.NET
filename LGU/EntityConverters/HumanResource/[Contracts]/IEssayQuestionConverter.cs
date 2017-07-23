using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEssayQuestionConverter<TDataReader> : IDataConverter<EssayQuestion, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
