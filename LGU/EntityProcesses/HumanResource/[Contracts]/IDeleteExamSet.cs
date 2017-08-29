using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteExamSet : IProcess<IExamSet>
    {
        IExamSet ExamSet { get; set; }
    }
}
