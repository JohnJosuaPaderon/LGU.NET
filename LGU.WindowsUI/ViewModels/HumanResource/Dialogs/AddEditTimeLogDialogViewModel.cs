using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Interactivity.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditTimeLogDialogViewModel : PopupViewModelBase<IAddEditTimeLogNotification>
    {
        public AddEditTimeLogDialogViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();

            SaveCommand = new DelegateCommand(Save);
            ChangePageCommand = new DelegateCommand<string>(ChangePage);
        }

        private readonly ITimeLogManager _TimeLogManager;

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand<string> ChangePageCommand { get; }

        private int _SelectedPage;
        public int SelectedPage
        {
            get { return _SelectedPage; }
            set { SetProperty(ref _SelectedPage, value); }
        }

        private async void Save()
        {
            await SaveAsync();
        }

        private void ChangePage(string arg)
        {
            SelectedPage = int.Parse(arg);
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
