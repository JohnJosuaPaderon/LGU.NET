using System;

namespace LGU.Entities.HumanResource
{
    public interface IExam : IEntity<long>
    {
        IApplication Application { get; }
        DateTime Date { get; set; }
        IExamSet Set { get; set; }
        int TotalScore { get; set; }
    }
}
