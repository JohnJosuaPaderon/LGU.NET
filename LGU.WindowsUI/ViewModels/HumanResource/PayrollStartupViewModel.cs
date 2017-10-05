using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.ViewModels.HumanResource.Dialogs;
using LGU.Views.HumanResource;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public class PayrollStartupViewModel : ViewModelBase, INavigationAware
    {
        private const string TEXT_HEADER = "Payroll Set-up";
        private const string SEARCH_KEY_MAYOR = "mayor";
        private const string SEARCH_KEY_HUMAN_RESOURCE_HEAD = "humanresourcehead";
        private const string SEARCH_KEY_TREASURER = "treasurer";
        private const string SEARCH_KEY_CITY_ACCOUNTANT = "cityaccountant";
        private const string SEARCH_KEY_CITY_BUDGET_OFFICER = "citybudgetofficer";
        private const string SEARCH_HINT_MAYOR = "Search Mayor...";
        private const string SEARCH_HINT_HUMAN_RESOURCE_HEAD = "Search Human Resource Head...";
        private const string SEARCH_HINT_TREASURER = "Search Treasurer...";
        private const string SEARCH_HINT_CITY_ACCOUNTANT = "Search City Accountant...";
        private const string SEARCH_HINT_CIT_BUDGET_OFFICER = "Search City Budget Officer...";
        private const string KEY_PAYROLL_DEFAULT_FILE = "HumanResource.Payroll.Default.FilePath";
        private const string FILTER_FILE = "Json Files (*.json) | *.json";
        private const string NAV_PARAM_PAYROLL = "payroll";

        public PayrollStartupViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _PayrollManager = ApplicationDomain.GetService<IPayrollManager<SqlConnection, SqlTransaction>>();
            _PayrollTypeManager = ApplicationDomain.GetService<IPayrollTypeManager>();

            _OpenFileDialog = new OpenFileDialog
            {
                Filter = FILTER_FILE
            };

            _SaveFileDialog = new SaveFileDialog
            {
                Filter = FILTER_FILE
            };

            SelectRangeDateCommand = new DelegateCommand(SelectRangeDate);
            SearchCommand = new DelegateCommand<string>(Search);
            LoadFromFileCommand = new DelegateCommand(LoadFromFile);
            SaveAsCommand = new DelegateCommand(SaveAs);
            ProceedCommand = new DelegateCommand(Proceed);
            SelectRangeDateRequest = new InteractionRequest<INotification>();
            SearchRequest = new InteractionRequest<INotification>();
            PayrollTypes = new ObservableCollection<PayrollTypeModel>();
        }

        private readonly IPayrollManager<SqlConnection, SqlTransaction> _PayrollManager;
        private readonly IPayrollTypeManager _PayrollTypeManager;
        private readonly OpenFileDialog _OpenFileDialog;
        private readonly SaveFileDialog _SaveFileDialog;

        public DelegateCommand SelectRangeDateCommand { get; }
        public DelegateCommand<string> SearchCommand { get; }
        public DelegateCommand LoadFromFileCommand { get; }
        public DelegateCommand SaveAsCommand { get; }
        public DelegateCommand ProceedCommand { get; }
        public InteractionRequest<INotification> SelectRangeDateRequest { get; }
        public InteractionRequest<INotification> SearchRequest { get; }
        public ObservableCollection<PayrollTypeModel> PayrollTypes { get; }

        private PayrollModel _Payroll;
        public PayrollModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
        }

        private async Task TryInitializeDefaultAsync()
        {
            if (Payroll == null)
            {
                await LoadFromFileAsync(ApplicationDomain.ResolveSystemPath(ConfigurationManager.AppSettings.GetString(KEY_PAYROLL_DEFAULT_FILE)));
            }
        }

        private async Task TryInitializePayrollTypeListAsync()
        {
            if (PayrollTypes.Count <= 0)
            {
                await LoadPayrollTypeListAsync();
            }
        }

        private async Task LoadFromFileAsync(string filePath)
        {
            var result = await _PayrollManager.GetDefaultFromFileAsync(filePath);
            Payroll = new PayrollModel(result.Data);

            if (Payroll != null)
            {
                var dateTime = DateTime.Now.AddDays(-15);
                if (dateTime.Day >= 1 || dateTime.Day <= 15)
                {
                    Payroll.RangeDate.Begin = new DateTime(dateTime.Year, dateTime.Month, 1);
                    Payroll.RangeDate.End = new DateTime(dateTime.Year, dateTime.Month, 15);
                }
                else
                {
                    Payroll.RangeDate.Begin = new DateTime(dateTime.Year, dateTime.Month, 16);
                    Payroll.RangeDate.End = new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
                }
            }
        }

        private async Task LoadPayrollTypeListAsync()
        {
            PayrollTypes.Clear();

            var result = await _PayrollTypeManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var payrollType in result.DataList)
                    {
                        PayrollTypes.Add(new PayrollTypeModel(payrollType));
                    }
                }
            }
            else
            {
                r_NewMessageEvent.Publish(result.Message);
            }
        }

        protected async override void Initialize()
        {
            await TryInitializeDefaultAsync();
            await TryInitializePayrollTypeListAsync();
        }

        private async void LoadFromFile()
        {
            if (_OpenFileDialog.ShowDialog() ?? false)
            {
                if (File.Exists(_OpenFileDialog.FileName))
                {
                    await LoadFromFileAsync(_OpenFileDialog.FileName);
                }
            }
        }

        private void Proceed()
        {
            if (Payroll != null)
            {
                if (Payroll.Type == null)
                {
                    r_NewMessageEvent.Publish("Payroll Type is invalid.");
                }
                else
                {
                    if (Payroll.RangeDate.Begin.Day >= 1 && Payroll.RangeDate.End.Day <= 15)
                    {
                        Payroll.CutOff = new PayrollCutOffModel(PayrollCutOff.FirstCutOff);
                    }
                    else if (Payroll.RangeDate.Begin.Day >= 16 && Payroll.RangeDate.End.Day <= 31)
                    {
                        Payroll.CutOff = new PayrollCutOffModel(PayrollCutOff.SecondCutOff);
                    }

                    if (Payroll.CutOff != null)
                    {
                        var parameters = new NavigationParameters()
                        {
                            { NAV_PARAM_PAYROLL, Payroll }
                        };
                        r_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(ContractualPayrollView), parameters);
                    }
                    else
                    {
                        r_NewMessageEvent.Publish("Cut-off couldn't determine.");
                    }
                }
            }
            else
            {
                r_NewMessageEvent.Publish("Invalid payroll.");
            }
        }

        private async void SaveAs()
        {
            if (_SaveFileDialog.ShowDialog() ?? false)
            {
                await _PayrollManager.SaveDefaultToFileAsync(Payroll.GetSource(), _SaveFileDialog.FileName);
            }
        }

        private void SelectRangeDate()
        {
            SelectRangeDateRequest.Raise(new Notification() { Title = string.Empty, Content = Payroll.RangeDate });
        }

        private void Search(string key)
        {
            var searchHint = string.Empty;

            switch (key)
            {
                case SEARCH_KEY_MAYOR:
                    searchHint = SEARCH_HINT_MAYOR;
                    break;
                case SEARCH_KEY_HUMAN_RESOURCE_HEAD:
                    searchHint = SEARCH_HINT_HUMAN_RESOURCE_HEAD;
                    break;
                case SEARCH_KEY_TREASURER:
                    searchHint = SEARCH_HINT_TREASURER;
                    break;
                case SEARCH_KEY_CITY_ACCOUNTANT:
                    searchHint = SEARCH_HINT_CITY_ACCOUNTANT;
                    break;
                case SEARCH_KEY_CITY_BUDGET_OFFICER:
                    searchHint = SEARCH_HINT_CIT_BUDGET_OFFICER;
                    break;
            }

            var notification = new Notification { Title = string.Empty, Content = new EmployeeSearchDialogContent(searchHint) };
            SearchRequest.Raise(notification, (n) => SearchRequestCallback(key, n.Content as EmployeeSearchDialogContent));
        }

        private void SearchRequestCallback(string searchKey, EmployeeSearchDialogContent content)
        {
            switch (searchKey)
            {
                case SEARCH_KEY_MAYOR:
                    Payroll.Mayor = content.SelectedEmployee;
                    break;
                case SEARCH_KEY_HUMAN_RESOURCE_HEAD:
                    Payroll.HumanResourceHead = content.SelectedEmployee;
                    break;
                case SEARCH_KEY_TREASURER:
                    Payroll.Treasurer = content.SelectedEmployee;
                    break;
                case SEARCH_KEY_CITY_ACCOUNTANT:
                    Payroll.CityAccountant = content.SelectedEmployee;
                    break;
                case SEARCH_KEY_CITY_BUDGET_OFFICER:
                    Payroll.CityBudgetOfficer = content.SelectedEmployee;
                    break;
                default:
                    break;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Payroll = navigationContext.Parameters[NAV_PARAM_PAYROLL] as PayrollModel;
            r_ChangeHeaderEvent.Publish(TEXT_HEADER);
        }
    }
}
