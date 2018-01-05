using System;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    partial class AddEditTimeLogDialogViewModel
    {
        private void LoadLoginYears()
        {
            LoginYears.Clear();
            var counter = DateTime.Now.Year;

            while (counter >= _MinYearCoverage)
            {
                LoginYears.Add(counter--);
            }

            SelectedLoginYear = PopupNotification.TimeLog.LoginDate?.Year;
        }

        private void LoadLoginMonths()
        {
            LoginMonths.Clear();
            var counter = 1;

            while (counter <= MONTHS_COUNT)
            {
                LoginMonths.Add(counter++);
            }

            SelectedLoginMonth = PopupNotification.TimeLog.LoginDate?.Month;
        }

        private void LoadLoginDays()
        {
            LoginDays.Clear();

            if ((SelectedLoginYear ?? 0) > 0 && (SelectedLoginMonth ?? 0) > 0)
            {
                var counter = 1;
                var daysCount = DateTime.DaysInMonth(SelectedLoginYear ?? 0, SelectedLoginMonth ?? 0);

                while (counter <= daysCount)
                {
                    LoginDays.Add(counter++);
                }

                SelectedLoginDay = PopupNotification.TimeLog.LoginDate?.Day;
            }
        }

        private void LoadLoginHours()
        {
            LoginHours.Clear();
            var counter = 0;

            while (counter < MAX_HOUR)
            {
                LoginHours.Add(counter++);
            }

            SelectedLoginHour = PopupNotification.TimeLog.LoginDate?.Hour;
        }

        private void LoadLoginMinutes()
        {
            LoginMinutes.Clear();
            var counter = 0;

            while (counter < MAX_MINUTE)
            {
                LoginMinutes.Add(counter++);
            }

            SelectedLoginMinute = PopupNotification.TimeLog.LoginDate?.Minute;
        }

        private void LoadLoginSeconds()
        {
            LoginSeconds.Clear();
            var counter = 0;

            while (counter < MAX_SECOND)
            {
                LoginSeconds.Add(counter++);
            }

            SelectedLoginSecond = PopupNotification.TimeLog.LoginDate?.Second;
        }

        private void LoadLogoutYears()
        {
            LogoutYears.Clear();
            var counter = DateTime.Now.Year;

            while (counter >= _MinYearCoverage)
            {
                LogoutYears.Add(counter--);
            }

            SelectedLogoutYear = PopupNotification.TimeLog.LogoutDate?.Year;
        }

        private void LoadLogoutMonths()
        {
            LogoutMonths.Clear();
            var counter = 1;

            while (counter <= MONTHS_COUNT)
            {
                LogoutMonths.Add(counter++);
            }

            SelectedLogoutMonth = PopupNotification.TimeLog.LogoutDate?.Month;
        }

        private void LoadLogoutDays()
        {
            LogoutDays.Clear();

            if ((SelectedLogoutYear ?? 0) > 0 && (SelectedLogoutMonth ?? 0) > 0)
            {
                var counter = 1;
                var daysCount = DateTime.DaysInMonth(SelectedLogoutYear ?? 0, SelectedLogoutMonth ?? 0);

                while (counter <= daysCount)
                {
                    LogoutDays.Add(counter++);
                }

                SelectedLogoutDay = PopupNotification.TimeLog.LogoutDate?.Day;
            }
        }

        private void LoadLogoutHours()
        {
            LogoutHours.Clear();
            var counter = 0;

            while (counter < MAX_HOUR)
            {
                LogoutHours.Add(counter++);
            }

            SelectedLogoutHour = PopupNotification.TimeLog.LogoutDate?.Hour;
        }

        private void LoadLogoutMinutes()
        {
            LogoutMinutes.Clear();
            var counter = 0;

            while (counter < MAX_MINUTE)
            {
                LogoutMinutes.Add(counter++);
            }

            SelectedLogoutMinute = PopupNotification.TimeLog.LogoutDate?.Minute;
        }

        private void LoadLogoutSeconds()
        {
            LogoutSeconds.Clear();
            var counter = 0;

            while (counter < MAX_SECOND)
            {
                LogoutSeconds.Add(counter++);
            }

            SelectedLogoutSecond = PopupNotification.TimeLog.LogoutDate?.Second;
        }

        private void LoadLogin()
        {
            LoadLoginYears();
            LoadLoginMonths();
            LoadLoginHours();
            LoadLoginMinutes();
            LoadLoginSeconds();

            if (PopupNotification.TimeLog.LoginDate == null)
            {
                ResetLoginProperties();
            }
        }

        private void LoadLogout()
        {
            LoadLogoutYears();
            LoadLogoutMonths();
            LoadLogoutHours();
            LoadLogoutMinutes();
            LoadLogoutSeconds();

            if (PopupNotification.TimeLog.LogoutDate == null)
            {
                ResetLogoutProperties();
            }
        }
    }
}
