using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class DepartmentHead : Person, IDepartmentHead
    {
        public string Title { get; set; }
    }
}
