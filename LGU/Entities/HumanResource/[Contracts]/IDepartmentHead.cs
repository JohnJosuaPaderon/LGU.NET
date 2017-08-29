using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IDepartmentHead : IPerson
    {
        string Title { get; set; }
    }
}
