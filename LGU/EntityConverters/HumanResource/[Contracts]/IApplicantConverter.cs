using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicantConverter<TDataReader> : IDataConverter<Applicant, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
