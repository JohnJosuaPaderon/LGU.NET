namespace LGU.Entities.HumanResource
{
    public class PayrollCutOff : Entity<short>, IPayrollCutOff
    {
        static PayrollCutOff()
        {
            FirstCutOff = new PayrollCutOff()
            {
                Id = 1,
                Count = 1,
                Description = "1st Cut-off"
            };

            SecondCutOff = new PayrollCutOff()
            {
                Id = 2,
                Count = 2,
                Description = "2nd Cut-off"
            };
        }

        public static PayrollCutOff FirstCutOff { get; }
        public static PayrollCutOff SecondCutOff { get; }

        public int Count { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
