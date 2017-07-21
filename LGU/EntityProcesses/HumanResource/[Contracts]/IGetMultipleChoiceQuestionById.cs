using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetMultipleChoiceQuestionById : IProcess<MultipleChoiceQuestion>
    {
        long MultipleChoiceQuestionId { get; set; }
    }
}
