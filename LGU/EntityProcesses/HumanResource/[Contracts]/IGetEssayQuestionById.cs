using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEssayQuestionById : IProcess<IEssayQuestion>
    {
        long EssayQuestionId { get; set; }
    }
}
