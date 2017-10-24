using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public class EmployeeSearchNotification : CustomNotification, IEmployeeSearchNotification
    {
        public EmployeeModel SelectedEmployee { get; set; }
    }
}
