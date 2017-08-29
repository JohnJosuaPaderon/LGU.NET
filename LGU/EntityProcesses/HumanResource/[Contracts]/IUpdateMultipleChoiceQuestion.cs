using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateMultipleChoiceQuestion : IProcess<IMultipleChoiceQuestion>
    {
        IMultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
