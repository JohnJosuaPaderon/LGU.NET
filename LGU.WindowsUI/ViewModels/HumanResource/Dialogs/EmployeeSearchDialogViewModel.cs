using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Interactivity.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class EmployeeSearchDialogViewModel : PopupViewModelBase<IEmployeeSearchNotification>
    {
        public EmployeeSearchDialogViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();

            SearchCommand = new DelegateCommand(Search);
            Employees = new ObservableCollection<EmployeeModel>();
        }

        private readonly IEmployeeManager _EmployeeManager;

        public DelegateCommand SearchCommand { get; }
        public ObservableCollection<EmployeeModel> Employees { get; }

        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set { SetProperty(ref _SearchKey, value); }
        }

        protected async override void Initialize()
        {
            if (PopupNotification.SelectedEmployee != null)
            {
                SearchKey = PopupNotification.SelectedEmployee.FullName ?? string.Empty;
                await SearchAsync();
            }
        }

        private async void Search()
        {
            await SearchAsync();
        }

        private async Task SearchAsync()
        {
            Employees.Clear();
            var result = await _EmployeeManager.SearchAsync(SearchKey);

            if (result.Status == ProcessResultStatus.Success)
            {
                LoadEmployees(result.DataList);
            }
            else
            {
                _NewMessageEvent.Publish(result.Message);
            }
        }

        private void LoadEmployees(IEnumerable<IEmployee> source)
        {
            if (source != null && source.Any())
            {
                foreach (var employee in source)
                {
                    Employees.Add(new EmployeeModel(employee));
                }

                PopupNotification.SelectedEmployee = Employees[0];
            }
        }
    }
}
