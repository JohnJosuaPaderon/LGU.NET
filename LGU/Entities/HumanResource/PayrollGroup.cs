using System;

namespace LGU.Entities.HumanResource
{
    public class PayrollGroup : Entity<int>
    {
        public PayrollGroup()
        {
        }

        public PayrollGroup(Department department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            Description = Department.Description;
        }

        public Department Department { get; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
