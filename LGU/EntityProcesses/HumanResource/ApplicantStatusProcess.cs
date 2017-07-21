using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicantStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicantStatusConverter<SqlDataReader> Converter;

        public ApplicantStatusProcess(IConnectionStringSource connectionStringSource, IApplicantStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
