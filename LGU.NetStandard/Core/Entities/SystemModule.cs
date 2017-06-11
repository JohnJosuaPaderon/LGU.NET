using LGU.Entities;

namespace LGU.Core.Entities
{
    public class SystemModule : Entity<uint>
    {
        public string[] Tags { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
