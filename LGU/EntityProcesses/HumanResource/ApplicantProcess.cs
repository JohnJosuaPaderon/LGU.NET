using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicantProcess : HumanResourceProcessBase
    {
        protected readonly IApplicantConverter<SqlDataReader> r_Converter;

        public ApplicantProcess(IConnectionStringSource connectionStringSource, IApplicantConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
