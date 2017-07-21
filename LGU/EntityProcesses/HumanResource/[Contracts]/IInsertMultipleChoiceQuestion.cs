using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertMultipleChoiceQuestion : IProcess<MultipleChoiceQuestion>
    {
        MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
