using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ISalaryGradeConverter<TDataReader> : IDataConverter<ISalaryGrade, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
