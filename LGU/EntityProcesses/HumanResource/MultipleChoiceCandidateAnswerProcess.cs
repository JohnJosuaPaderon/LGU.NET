using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class MultipleChoiceCandidateAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IMultipleChoiceCandidateAnswerConverter _Converter;

        public MultipleChoiceCandidateAnswerProcess(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
