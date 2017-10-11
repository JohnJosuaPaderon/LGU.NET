using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentConverter<TDataReader> : IDataConverter<IDepartment, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<int> PId { get; }
        IDataConverterProperty<string> PDescription { get; }
        IDataConverterProperty<string> PAbbreviation { get; }
        IDataConverterProperty<IDepartmentHead> PHead { get; }
    }
}
