using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetMultipleChoiceQuestionById : IProcess<IMultipleChoiceQuestion>
    {
        long MultipleChoiceQuestionId { get; set; }
    }
}
