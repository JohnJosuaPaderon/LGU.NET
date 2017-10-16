using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicantProcess : HumanResourceProcessBase
    {
        protected readonly IApplicantConverter _Converter;

        public ApplicantProcess(IConnectionStringSource connectionStringSource, IApplicantConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
