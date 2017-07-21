using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertExamSet : IProcess<ExamSet>
    {
        ExamSet ExamSet { get; set; }
    }
}
