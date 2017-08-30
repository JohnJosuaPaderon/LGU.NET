using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ISalaryGradeStepConverter<TDataReader> : IDataConverter<ISalaryGradeStep, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
