using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateMultipleChoiceQuestion : IProcess<MultipleChoiceQuestion>
    {
        MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
