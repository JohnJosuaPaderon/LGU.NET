using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class DepartmentHeadParameters : PersonParameters, IDepartmentHeadParameters
    {
        public DepartmentHeadParameters()
        {
            Title = "@_Title";
        }

        public string Title { get; }
    }
}
