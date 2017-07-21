using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetExamSetById : IProcess<ExamSet>
    {
        long ExamSetId { get; set; }
    }
}
