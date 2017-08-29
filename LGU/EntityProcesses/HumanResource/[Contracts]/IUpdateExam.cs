using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateExam : IProcess<IExam>
    {
        IExam Exam { get; set; }
    }
}
