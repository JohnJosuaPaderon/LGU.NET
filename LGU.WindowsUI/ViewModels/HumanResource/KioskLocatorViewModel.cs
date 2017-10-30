using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Reports;
using LGU.Reports.HumanResource;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public class KioskLocatorViewModel : ViewModelBase, IExportEventHandler
    {
        public KioskLocatorViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_LocatorLeaveTypeManager = ApplicationDomain.GetService<ILocatorLeaveTypeManager>();
            r_HumanResourceReport = ApplicationDomain.GetService<IHumanResourceReport>();
            r_LocatorManager = ApplicationDomain.GetService<ILocatorManager>();
            r_KioskEmployeeChangedEvent = _EventAggregator.GetEvent<KioskEmployeeChangedEvent>();

            ChangeOfficeOutTimePageCommand = new DelegateCommand<object>(ChangeOfficeOutTimePage);
            ChangeExpectedReturnTimePageCommand = new DelegateCommand<object>(ChangeExpectedReturnTimePage);
            PrintCommand = new DelegateCommand(Print);
            LeaveTypes = new ObservableCollection<ILocatorLeaveType>();
            Locator = new LocatorModel(new Locator(MainKioskViewModel.SelectedKioskEmployee.GetSource()))
            {
                Date = DateTime.Now,
                OfficeOutTime = DateTime.Now,
                ExpectedReturnTime = DateTime.Now
            };
            r_KioskEmployeeChangedEvent.Subscribe(OnKioskEmployeeChanged);
        }

        private readonly KioskEmployeeChangedEvent r_KioskEmployeeChangedEvent;
        private readonly ILocatorLeaveTypeManager r_LocatorLeaveTypeManager;
        private readonly IHumanResourceReport r_HumanResourceReport;
        private readonly ILocatorManager r_LocatorManager;

        public DelegateCommand<object> ChangeOfficeOutTimePageCommand { get; }
        public DelegateCommand<object> ChangeExpectedReturnTimePageCommand { get; }
        public DelegateCommand PrintCommand { get; }
        public ObservableCollection<ILocatorLeaveType> LeaveTypes { get; }

        private LocatorModel _Locator;
        public LocatorModel Locator
        {
            get { return _Locator; }
            set { SetProperty(ref _Locator, value); }
        }

        private int _SelectedOfficeOutTimePage;
        public int SelectedOfficeOutTimePage
        {
            get { return _SelectedOfficeOutTimePage; }
            set { SetProperty(ref _SelectedOfficeOutTimePage, value); }
        }

        private int _SelectedExpectedReturnTimePage;
        public int SelectedExpectedReturnTimePage
        {
            get { return _SelectedExpectedReturnTimePage; }
            set { SetProperty(ref _SelectedExpectedReturnTimePage, value); }
        }

        private void OnKioskEmployeeChanged(EmployeeModel employee)
        {
            if (employee != null)
            {
                Locator = new LocatorModel(new Locator(employee.GetSource()))
                {
                    Date = DateTime.Now,
                    OfficeOutTime = DateTime.Now,
                    ExpectedReturnTime = DateTime.Now
                };
            }
            else
            {
                Locator = null;
            }
        }

        private async void Print()
        {
            var result = await r_LocatorManager.InsertAsync(Locator.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                await r_HumanResourceReport.ExportLocatorAsync(result.Data, this);
                _RegionManager.RequestNavigate(MainKioskViewModel.KioskContentRegion, nameof(KioskServiceSelectionView));
            }
            else
            {
                _NewMessageEvent.Publish(result.Message);
            }
        }

        private void ChangeOfficeOutTimePage(object page)
        {
            SelectedOfficeOutTimePage = Convert.ToInt32(page);
        }

        private void ChangeExpectedReturnTimePage(object page)
        {
            SelectedExpectedReturnTimePage = Convert.ToInt32(page);
        }

        protected async override void Initialize()
        {
            await GetLeaveTypesAsync();
        }

        private async Task GetLeaveTypesAsync()
        {
            var result = await r_LocatorLeaveTypeManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    LeaveTypes.Clear();
                    foreach (var item in result.DataList)
                    {
                        LeaveTypes.Add(item);
                    }
                }
            }
            else
            {
                _NewMessageEvent.Publish(result.Message);
            }
        }

        #region Export Events
        public void OnException(Exception exception)
        {
            _NewMessageEvent.Publish(exception.Message);
        }

        public void OnError(string message)
        {
            _NewMessageEvent.Publish(message);
        }

        public void OnExported(string[] filePaths)
        {
            _NewMessageEvent.Publish("Successfully exported.");
        }

        public void OnExported(string filePath)
        {
            _NewMessageEvent.Publish("Successfully exported.");
        }
        #endregion
    }
}
