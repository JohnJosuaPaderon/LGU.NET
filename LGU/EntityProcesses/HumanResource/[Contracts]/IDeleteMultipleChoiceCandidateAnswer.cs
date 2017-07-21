﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteMultipleChoiceCandidateAnswer : IProcess<MultipleChoiceCandidateAnswer>
    {
        MultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }
    }
}
