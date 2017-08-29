namespace LGU.Entities.HumanResource
{
    public class TimeLogType : Entity<short>, ITimeLogType
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
