using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamSetProcess : HumanResourceProcessBase
    {
        protected readonly IExamSetConverter _Converter;

        public ExamSetProcess(IConnectionStringSource connectionStringSource, IExamSetConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
