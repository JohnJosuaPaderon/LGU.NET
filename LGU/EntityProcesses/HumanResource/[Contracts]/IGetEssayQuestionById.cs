using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEssayQuestionById : IProcess<EssayQuestion>
    {
        long EssayQuestionId { get; set; }
    }
}
