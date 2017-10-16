using LGU.Entities.Core;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.Core
{
    public interface IPersonConverter : IDataConverter<IPerson>
    {
        IDataConverterProperty<long> Prop_Id { get; }
        IDataConverterProperty<string> Prop_FirstName { get; }
        IDataConverterProperty<string> Prop_MiddleName { get; }
        IDataConverterProperty<string> Prop_LastName { get; }
        IDataConverterProperty<string> Prop_NameExtension { get; }
        IDataConverterProperty<string> Prop_MiddleInitials { get; }
        IDataConverterProperty<DateTime?> Prop_BirthDate { get; }
        IDataConverterProperty<IGender> Prop_Gender { get; }
        IDataConverterProperty<bool> Prop_Deceased { get; }
    }
}
