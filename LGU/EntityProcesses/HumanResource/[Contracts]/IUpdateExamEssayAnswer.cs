using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateExamEssayAnswer : IProcess<ExamEssayAnswer>
    {
        ExamEssayAnswer ExamEssayAnswer { get; set; }
    }
}
