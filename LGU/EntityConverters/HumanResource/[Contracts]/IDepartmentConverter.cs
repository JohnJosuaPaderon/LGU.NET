using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentConverter : IDataConverter<IDepartment>
    {
        IDataConverterProperty<int> PId { get; }
        IDataConverterProperty<string> PDescription { get; }
        IDataConverterProperty<string> PAbbreviation { get; }
        IDataConverterProperty<IEmployee> PHead { get; }
    }
}
