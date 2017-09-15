using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsChild : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; }
        IPerson Person { get; set; }
        string Name { get; set; }
        DateTime BirthDate { get; set; }
    }
}
