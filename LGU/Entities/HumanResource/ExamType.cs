namespace LGU.Entities.HumanResource
{
    public class ExamType : Entity<short>
    {
        public string Description { get; set; }
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
