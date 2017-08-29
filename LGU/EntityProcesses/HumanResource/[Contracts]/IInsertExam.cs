using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertExam : IProcess<IExam>
    {
        IExam Exam { get; set; }
    }
}
