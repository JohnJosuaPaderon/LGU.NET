using LGU.Interactivity.HumanResource;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class ContractualPayrollSignatoryDialogViewModel : PopupViewModelBase<IContractualPayrollSignatoryNotification>
    {
        private const string SEARCH_KEY_MAYOR = "mayor";
        private const string SEARCH_KEY_HUMAN_RESOURCE_HEAD = "humanresourcehead";
        private const string SEARCH_KEY_TREASURER = "treasurer";
        private const string SEARCH_KEY_CITY_ACCOUNTANT = "cityaccountant";
        private const string SEARCH_KEY_CITY_BUDGET_OFFICER = "citybudgetofficer";
        private const string SEARCH_HINT_MAYOR = "Search Mayor...";
        private const string SEARCH_HINT_HUMAN_RESOURCE_HEAD = "Human Resource Head...";
        private const string SEARCH_HINT_TREASURER = "Treasurer...";
        private const string SEARCH_HINT_CITY_ACCOUNTANT = "City Accountant...";
        private const string SEARCH_HINT_CITY_BUDGET_OFFICER = "City Budget Officer...";

        public ContractualPayrollSignatoryDialogViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            SearchEmployeeCommand = new DelegateCommand<string>(SearchEmployee);
            EmployeeSearchRequest = new InteractionRequest<IEmployeeSearchNotification>();
        }

        public DelegateCommand<string> SearchEmployeeCommand { get; }
        public InteractionRequest<IEmployeeSearchNotification> EmployeeSearchRequest { get; }

        private void SearchEmployee(string searchKey)
        {
            string searchHint = null;
            EmployeeModel selectedEmployee = null;

            switch (searchKey)
            {
                case SEARCH_KEY_MAYOR:
                    searchHint = SEARCH_HINT_MAYOR;
                    selectedEmployee = PopupNotification.Payroll.Mayor;
                    break;
                case SEARCH_KEY_HUMAN_RESOURCE_HEAD:
                    searchHint = SEARCH_HINT_HUMAN_RESOURCE_HEAD;
                    selectedEmployee = PopupNotification.Payroll.HumanResourceHead;
                    break;
                case SEARCH_KEY_TREASURER:
                    searchHint = SEARCH_HINT_TREASURER;
                    selectedEmployee = PopupNotification.Payroll.Treasurer;
                    break;
                case SEARCH_KEY_CITY_ACCOUNTANT:
                    searchHint = SEARCH_HINT_CITY_ACCOUNTANT;
                    selectedEmployee = PopupNotification.Payroll.CityAccountant;
                    break;
                case SEARCH_KEY_CITY_BUDGET_OFFICER:
                    searchHint = SEARCH_HINT_CITY_BUDGET_OFFICER;
                    selectedEmployee = PopupNotification.Payroll.CityBudgetOfficer;
                    break;
                default:
                    break;
            }

            EmployeeSearchRequest.Raise(new EmployeeSearchNotification(searchHint, searchKey, selectedEmployee), SearchEmployeeCallback);
        }

        private void SearchEmployeeCallback(IEmployeeSearchNotification notification)
        {
            switch (notification.SearchKey)
            {
                case SEARCH_KEY_MAYOR:
                    PopupNotification.Payroll.Mayor = notification.SelectedEmployee;
                    break;
                case SEARCH_KEY_HUMAN_RESOURCE_HEAD:
                    PopupNotification.Payroll.HumanResourceHead = notification.SelectedEmployee;
                    break;
                case SEARCH_KEY_TREASURER:
                    PopupNotification.Payroll.Treasurer = notification.SelectedEmployee;
                    break;
                case SEARCH_KEY_CITY_ACCOUNTANT:
                    PopupNotification.Payroll.CityAccountant = notification.SelectedEmployee;
                    break;
                case SEARCH_KEY_CITY_BUDGET_OFFICER:
                    PopupNotification.Payroll.CityBudgetOfficer = notification.SelectedEmployee;
                    break;
                default:
                    break;
            }
        }
    }
}
