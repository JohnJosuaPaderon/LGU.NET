using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditLocatorDialogViewModel : DialogViewModelBase
    {
        private readonly AddLocatorEvent r_AddEvent;
        private readonly EditLocatorEvent r_EditEvent;

        public AddEditLocatorDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_AddEvent = _EventAggregator.GetEvent<AddLocatorEvent>();
            r_EditEvent = _EventAggregator.GetEvent<EditLocatorEvent>();
            r_AddEvent.Subscribe(arg => SetData(arg, "Add new Locator", DialogMode.Add));
            r_EditEvent.Subscribe(arg => SetData(arg, "Edit Locator", DialogMode.Edit));

            ConfirmRequestorCommand = new DelegateCommand<EmployeeModel>(ConfirmRequestor);
            ChangePageCommand = new DelegateCommand<object>(ChangePage);
        }

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand<object> ChangePageCommand { get; }
        public DelegateCommand<EmployeeModel> ConfirmRequestorCommand { get; }

        private LocatorModel _Locator;
        public LocatorModel Locator
        {
            get { return _Locator; }
            set { SetProperty(ref _Locator, value); }
        }

        private int _SelectedPage;
        public int SelectedPage
        {
            get { return _SelectedPage; }
            set { SetProperty(ref _SelectedPage, value); }
        }

        private void ConfirmRequestor(EmployeeModel employee)
        {
            if (employee != null)
            {
            }

            ChangePage(0);
        }

        private void ChangePage(object page)
        {
            SelectedPage = Convert.ToInt32(page);
        }

        private void SetData(LocatorModel locator, string headerTitle, DialogMode mode)
        {
            Locator = locator;
            HeaderTitle = headerTitle;
            Mode = mode;
            ChangePage(mode == DialogMode.Add ? 1 : 0);
        }
    }
}
