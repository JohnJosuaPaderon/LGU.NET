﻿using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IDocumentPathTypeConverter<TDataReader> : IDataConverter<DocumentPathType, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}