using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetExamById : IProcess<Exam>
    {
        long ExamId { get; set; }
    }
}
