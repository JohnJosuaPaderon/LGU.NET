using LGU.Entities;

namespace LGU.HumanResource.Entities
{
    public class EmployeePosition : Entity<uint>
    {
        public string Name { get; set; }
        public uint HierarchicalLevel { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
