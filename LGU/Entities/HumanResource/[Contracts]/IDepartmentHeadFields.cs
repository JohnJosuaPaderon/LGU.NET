using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IDepartmentHeadFields : IPersonFields
    {
        string Title { get; }
    }
}
