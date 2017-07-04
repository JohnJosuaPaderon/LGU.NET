using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Employee : Person
    {
        public Department Department { get; set; }
    }
}
