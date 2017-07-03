namespace LGU.Entities.HumanResource
{
    public class Position : Entity<ulong>
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
