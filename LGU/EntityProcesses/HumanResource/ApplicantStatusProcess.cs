using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicantStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicantStatusConverter _Converter;

        public ApplicantStatusProcess(IConnectionStringSource connectionStringSource, IApplicantStatusConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
