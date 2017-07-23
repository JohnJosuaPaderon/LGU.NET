using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicantStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicantStatusConverter<SqlDataReader> r_Converter;

        public ApplicantStatusProcess(IConnectionStringSource connectionStringSource, IApplicantStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
