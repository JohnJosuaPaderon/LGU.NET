using System;
using System.Collections.Generic;
using System.Text;

namespace LGU.Entities.Core
{
    public interface IPersonalDataSheetSpouse : IEntity<long>
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameExtension { get; set; }
    }
}
