using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Interactivity.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed partial class AddEditTimeLogDialogViewModel : PopupViewModelBase<IAddEditTimeLogNotification>
    {
        public AddEditTimeLogDialogViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();
            _MinYearCoverage = ConfigurationManager.AppSettings.GetInt32(CONFIG_MIN_YEAR_COVERAGE);

            SaveCommand = new DelegateCommand(Save);
            ChangePageCommand = new DelegateCommand<string>(ChangePage);
            LoginToggleCommand = new DelegateCommand(LoginToggle);
            LogoutToggleCommand = new DelegateCommand(LogoutToggle);
            LoginYears = new ObservableCollection<int?>();
            LoginMonths = new ObservableCollection<int?>();
            LoginDays = new ObservableCollection<int?>();
            LoginHours = new ObservableCollection<int?>();
            LoginMinutes = new ObservableCollection<int?>();
            LoginSeconds = new ObservableCollection<int?>();
            LogoutYears = new ObservableCollection<int?>();
            LogoutMonths = new ObservableCollection<int?>();
            LogoutDays = new ObservableCollection<int?>();
            LogoutHours = new ObservableCollection<int?>();
            LogoutMinutes = new ObservableCollection<int?>();
            LogoutSeconds = new ObservableCollection<int?>();
        }

        private void ResetLoginProperties()
        {
            SelectedLoginYear = null;
            SelectedLoginMonth = null;
            SelectedLoginDay = null;
            SelectedLoginHour = null;
            SelectedLoginMinute = null;
            SelectedLoginSecond = null;
        }

        private void ResetLogoutProperties()
        {
            SelectedLogoutYear = null;
            SelectedLogoutMonth = null;
            SelectedLogoutDay = null;
            SelectedLogoutHour = null;
            SelectedLogoutMinute = null;
            SelectedLogoutSecond = null;
        }

        private Task SaveAsync()
        {
            Func<ITimeLog, Task<IProcessResult<ITimeLog>>> processAsync = null;
            
            switch (PopupNotification.Mode)
            {
                case AddEditTimeLogMode.Add:
                    processAsync = _TimeLogManager.InsertAsync;
                    break;
                case AddEditTimeLogMode.Edit:
                    processAsync = _TimeLogManager.UpdateAsync;
                    break;
            }

            return SaveAsync(processAsync);
        }

        private async Task SaveAsync(Func<ITimeLog, Task<IProcessResult<ITimeLog>>> processAsync)
        {
            if (SetLogin)
            {
                if (IsInvalidLogin())
                {
                    return;
                }
            }
            else
            {
                PopupNotification.TimeLog.LoginDate = null;
            }

            if (SetLogout)
            {
                if (IsInvalidLogout())
                {
                    return;
                }
            }
            else
            {
                PopupNotification.TimeLog.LogoutDate = null;
            }

            var result = await processAsync(PopupNotification.TimeLog.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                Close();
            }
            else
            {
                _NewMessageEvent.EnqueueErrorMessage(result.Message);
            }
        }
    }
}
