using LGU.Models.HumanResource;
using Prism.Events;

namespace LGU.Events.HumanResource
{
    public class AddDepartmentEvent : PubSubEvent<DepartmentModel>
    {
    }
}
