using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace LGU.ViewModels
{
    public static class DialogHelper
    {
        public static void CloseDialog()
        {
            var command = (ICommand)DialogHost.CloseDialogCommand;
            command.Execute(null);
        }
    }
}
