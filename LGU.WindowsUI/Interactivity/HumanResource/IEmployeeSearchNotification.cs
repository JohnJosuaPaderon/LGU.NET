using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public interface IEmployeeSearchNotification : ICustomNotification
    {
        EmployeeModel SelectedEmployee { get; set; }
        string SearchHint { get; set; }
        string SearchKey { get; set; }
    }
}
