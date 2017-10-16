using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EssayQuestionProcess : HumanResourceProcessBase
    {
        protected readonly IEssayQuestionConverter _Converter;

        public EssayQuestionProcess(IConnectionStringSource connectionStringSource, IEssayQuestionConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
