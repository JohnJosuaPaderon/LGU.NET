using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertExam : IProcess<Exam>
    {
        Exam Exam { get; set; }
    }
}
