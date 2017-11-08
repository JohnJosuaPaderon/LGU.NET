using LGU.Models.HumanResource;
using System;

namespace LGU.Interactivity.HumanResource
{
    public class EmployeeSearchNotification : CustomNotification, IEmployeeSearchNotification
    {
        public EmployeeSearchNotification(string searchHint, string searchKey, EmployeeModel selectedEmployee)
        {
            SearchHint = string.IsNullOrWhiteSpace(searchHint) ? "Search..." : searchHint;
            SearchKey = !string.IsNullOrWhiteSpace(searchKey) ? searchKey : throw new ArgumentException(nameof(searchKey));
            SelectedEmployee = selectedEmployee;
        }

        private EmployeeModel _SelectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value); }
        }

        private string _SearchHint;
        public string SearchHint
        {
            get { return _SearchHint; }
            set { SetProperty(ref _SearchHint, value); }
        }

        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set { SetProperty(ref _SearchKey, value); }
        }
    }
}
