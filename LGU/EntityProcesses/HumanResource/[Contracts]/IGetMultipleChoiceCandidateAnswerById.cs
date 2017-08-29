using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetMultipleChoiceCandidateAnswerById : IProcess<IMultipleChoiceCandidateAnswer>
    {
        long MultipleChoiceCandidateAnswerId { get; set; }
    }
}
