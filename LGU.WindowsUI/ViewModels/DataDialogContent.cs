using Prism.Mvvm;

namespace LGU.ViewModels
{
    public class DataDialogContent : BindableBase
    {
        private DialogMode _Mode;
        public DialogMode Mode
        {
            get { return _Mode; }
            set { SetProperty(ref _Mode, value); }
        }

        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }
    }
}
