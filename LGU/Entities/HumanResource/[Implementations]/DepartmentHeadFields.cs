using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class DepartmentHeadFields : PersonFields, IDepartmentHeadFields
    {
        public DepartmentHeadFields()
        {
            Title = "Title";
        }

        public string Title { get; }
    }
}
