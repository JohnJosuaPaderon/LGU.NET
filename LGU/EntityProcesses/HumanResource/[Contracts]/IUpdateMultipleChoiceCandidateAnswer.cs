using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateMultipleChoiceCandidateAnswer : IProcess<MultipleChoiceCandidateAnswer>
    {
        MultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }
    }
}
