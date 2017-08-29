using System;

namespace LGU.Entities.HumanResource
{
    public class Department : Entity<int>, IDepartment
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public IDepartmentHead Head { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
