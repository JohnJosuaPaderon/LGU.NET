namespace LGU.Entities.Core
{
    public class Module : Entity<short>, IModule
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
