using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateExamMultipleChoiceAnswer : IProcess<ExamMultipleChoiceAnswer>
    {
        ExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }
    }
}
