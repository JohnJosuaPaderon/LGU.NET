using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertMultipleChoiceCandidateAnswer : IProcess<IMultipleChoiceCandidateAnswer>
    {
        IMultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }
    }
}
