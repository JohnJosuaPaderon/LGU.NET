﻿namespace LGU.Entities.HumanResource
{
    public interface IPayrollDepartmentParameters
    {
        string Id { get; }
        string DepartmentId { get; }
        string PayrollId { get; }
        string HeadId { get; }
        string Ordinal { get; }
    }
}
