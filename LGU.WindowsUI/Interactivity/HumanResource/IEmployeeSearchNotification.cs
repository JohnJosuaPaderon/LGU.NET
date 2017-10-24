using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public interface IEmployeeSearchNotification : ICustomNotification
    {
        EmployeeModel SelectedEmployee { get; set; }
    }
}
