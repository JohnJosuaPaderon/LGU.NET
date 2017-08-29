namespace LGU.Entities.HumanResource
{
    public class LocatorLeaveType : Entity<short>, ILocatorLeaveType
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
