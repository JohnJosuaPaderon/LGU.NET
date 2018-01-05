namespace LGU.ViewModels.HumanResource.Dialogs
{
    partial class AddEditTimeLogDialogViewModel
    {
        protected override void Initialize()
        {
            SetLogin = PopupNotification.TimeLog.LoginDate != null;
            SetLogout = PopupNotification.TimeLog.LogoutDate != null;

            LoadLogin();
            LoadLogout();
        }

        private void LoginToggle()
        {
            LoadLogin();
        }

        private void LogoutToggle()
        {
            LoadLogout();
        }

        private async void Save()
        {
            await SaveAsync();
        }

        private void ChangePage(string arg)
        {
            SelectedPage = int.Parse(arg);
        }
    }
}
