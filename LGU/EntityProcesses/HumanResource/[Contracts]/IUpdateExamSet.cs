using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateExamSet : IProcess<IExamSet>
    {
        IExamSet ExamSet { get; set; }
    }
}
