using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertExamEssayAnswer : IProcess<IExamEssayAnswer>
    {
        IExamEssayAnswer ExamEssayAnswer { get; set; }
    }
}
