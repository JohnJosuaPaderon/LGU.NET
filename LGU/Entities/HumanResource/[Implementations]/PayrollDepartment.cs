﻿namespace LGU.Entities.HumanResource
{
    public abstract class PayrollDepartment : IPayrollDepartment
    {
        public IDepartment Department { get; set; }
        public IDepartmentHead Head { get; set; }
        public int Ordinal { get; set; }
    }
}
