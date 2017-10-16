using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamEssayAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IExamEssayAnswerConverter _Converter;

        public ExamEssayAnswerProcess(IConnectionStringSource connectionStringSource, IExamEssayAnswerConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
