﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertExamMultipleChoiceAnswer : IProcess<IExamMultipleChoiceAnswer>
    {
        IExamMultipleChoiceAnswer ExamMultipleChoiceAnswer { get; set; }
    }
}
