using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamProcess : HumanResourceProcessBase
    {
        protected readonly IExamConverter _Converter;

        public ExamProcess(IConnectionStringSource connectionStringSource, IExamConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
