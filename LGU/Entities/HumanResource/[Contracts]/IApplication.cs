using System;

namespace LGU.Entities.HumanResource
{
    public interface IApplication : IEntity<long>
    {
        IApplicant Applicant { get; }
        IApplicationStatus Status { get; }
        DateTime Date { get; set; }
        IPosition ApplyingPosition { get; set; }
    }
}
