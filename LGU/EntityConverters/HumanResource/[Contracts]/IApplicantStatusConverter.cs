using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicantStatusConverter<TDataReader> : IDataConverter<IApplicantStatus, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
