namespace LGU.Entities.HumanResource
{
    public class ApplicationStatus : Entity<ushort>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
