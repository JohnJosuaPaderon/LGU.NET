using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateExamEssayAnswer : IProcess<IExamEssayAnswer>
    {
        IExamEssayAnswer ExamEssayAnswer { get; set; }
    }
}
