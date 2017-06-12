using LGU.Entities;

namespace LGU.Core.Entities
{
    public class ComputerUser : Entity<ulong>
    {
        public ComputerUser(Computer computer)
        {
            Computer = computer ?? throw LGUException.ArgumentNull(nameof(computer), "Computer is not valid.");
        }

        public Computer Computer { get; }
        public string Name { get; set; }
        public Accessibility Accessibility { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
