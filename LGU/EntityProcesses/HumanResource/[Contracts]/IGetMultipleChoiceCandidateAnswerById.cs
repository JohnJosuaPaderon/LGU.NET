using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetMultipleChoiceCandidateAnswerById : IProcess<MultipleChoiceCandidateAnswer>
    {
        long MultipleChoiceCandidateAnswerId { get; set; }
    }
}
