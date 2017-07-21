using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteExamMultipleChoiceAnswer : IProcess<ExamMultipleChoiceAnswer>
    {
        ExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }
    }
}
