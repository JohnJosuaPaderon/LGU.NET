using LGU.Entities;

namespace LGU.Core.Entities
{
    public class Device : Entity<ulong>
    {
        public string Name { get; set; }
    }
}
