﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IExamEssayAnswerConverter<TDataReader> : IDataConverter<ExamEssayAnswer, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}