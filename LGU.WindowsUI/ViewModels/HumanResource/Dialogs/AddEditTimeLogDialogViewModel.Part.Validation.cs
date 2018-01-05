using System;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    partial class AddEditTimeLogDialogViewModel
    {
        private bool IsInvalid(int? arg)
        {
            return arg == null;
        }

        private bool IsInvalidYear(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < _MinYearCoverage && arg.Value > DateTime.Now.Year);
        }

        private bool IsInvalidMonth(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < 1 && arg.Value > MONTHS_COUNT);
        }

        private bool IsInvalidDay(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < 1 && arg.Value > DateTime.DaysInMonth(SelectedLoginYear.Value, SelectedLoginMonth.Value));
        }

        private bool IsInvalidHour(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < 0 && arg.Value > 23);
        }

        private bool IsInvalidMinute(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < 0 && arg.Value > 59);
        }

        private bool IsInvalidSecond(int? arg)
        {
            return IsInvalid(arg) || (arg.Value < 0 && arg.Value > 59);
        }

        private bool IsInvalidLogin()
        {
            if (IsInvalidYear(SelectedLoginYear))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid year part of login.");
            }
            else if (IsInvalidMonth(SelectedLoginMonth))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid month part of login.");
            }
            else if (IsInvalidDay(SelectedLoginDay))
            {
                _NewMessageEvent.EnqueueMessage("Invalid day part of login.");
            }
            else if (IsInvalidHour(SelectedLoginHour))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid hour part of login.");
            }
            else if (IsInvalidMinute(SelectedLoginMinute))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid minute part of login.");
            }
            else if (IsInvalidSecond(SelectedLoginSecond))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid second part of login.");
            }
            else
            {
                PopupNotification.TimeLog.LoginDate = new DateTime(
                    SelectedLoginYear.Value,
                    SelectedLoginMonth.Value,
                    SelectedLoginDay.Value,
                    SelectedLoginHour.Value,
                    SelectedLoginMinute.Value,
                    SelectedLoginSecond.Value);

                return false;
            }

            return true;
        }

        private bool IsInvalidLogout()
        {
            if (IsInvalidYear(SelectedLogoutYear))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid year part of logout.");
            }
            else if (IsInvalidMonth(SelectedLogoutMonth))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid month part of logout.");
            }
            else if (IsInvalidDay(SelectedLogoutDay))
            {
                _NewMessageEvent.EnqueueMessage("Invalid day part of logout.");
            }
            else if (IsInvalidHour(SelectedLogoutHour))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid hour part of logout.");
            }
            else if (IsInvalidMinute(SelectedLogoutMinute))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid minute part of logout.");
            }
            else if (IsInvalidSecond(SelectedLogoutSecond))
            {
                _NewMessageEvent.EnqueueErrorMessage("Invalid second part of logout.");
            }
            else
            {
                PopupNotification.TimeLog.LogoutDate = new DateTime(
                    SelectedLogoutYear.Value,
                    SelectedLogoutMonth.Value,
                    SelectedLogoutDay.Value,
                    SelectedLogoutHour.Value,
                    SelectedLogoutMinute.Value,
                    SelectedLogoutSecond.Value);

                return false;
            }

            return true;
        }
    }
}
