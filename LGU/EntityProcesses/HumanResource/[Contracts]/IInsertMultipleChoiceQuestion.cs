using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertMultipleChoiceQuestion : IProcess<IMultipleChoiceQuestion>
    {
        IMultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
