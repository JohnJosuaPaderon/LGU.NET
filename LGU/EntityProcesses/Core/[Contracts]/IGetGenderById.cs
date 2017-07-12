using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetGenderById : IDataProcess<Gender>
    {
        short GenderId { get; set; }
    }
}
