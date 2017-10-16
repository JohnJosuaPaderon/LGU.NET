using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamMultipleChoiceAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IExamMultipleChoiceAnswerConverter _Converter;

        public ExamMultipleChoiceAnswerProcess(IConnectionStringSource connectionStringSource, IExamMultipleChoiceAnswerConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
