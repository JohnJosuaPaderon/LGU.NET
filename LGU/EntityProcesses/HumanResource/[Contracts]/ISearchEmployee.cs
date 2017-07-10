using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchEmployee : IEnumerableDataProcess<Employee>
    {
        string SearchKey { get; set; }
    }
}
