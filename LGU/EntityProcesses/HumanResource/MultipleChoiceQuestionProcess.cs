using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class MultipleChoiceQuestionProcess : HumanResourceProcessBase
    {
        protected readonly IMultipleChoiceQuestionConverter _Converter;

        public MultipleChoiceQuestionProcess(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
