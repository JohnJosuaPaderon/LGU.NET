using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentConverter<TDataReader> : IDataConverter<IDepartment, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<int> Prop_Id { get; }
        IDataConverterProperty<string> Prop_Description { get; }
        IDataConverterProperty<string> Prop_Abbreviation { get; }
        IDataConverterProperty<IDepartmentHead> Prop_Head { get; }
    }
}
