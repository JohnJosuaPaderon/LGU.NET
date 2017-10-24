using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IDepartmentHeadParameters : IPersonParameters
    {
        string Title { get; }
    }
}
