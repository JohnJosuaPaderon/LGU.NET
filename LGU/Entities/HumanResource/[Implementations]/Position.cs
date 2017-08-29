namespace LGU.Entities.HumanResource
{
    public class Position : Entity<int>, IPosition
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
