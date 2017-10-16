using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityConverters.Core
{
    public interface IGenderConverter : IDataConverter<IGender>
    {
        IDataConverterProperty<short> Prop_Id { get; }
        IDataConverterProperty<string> Prop_Description { get; }
    }
}
