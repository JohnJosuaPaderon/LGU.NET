using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Department : Entity<uint>
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
