using MaterialDesignThemes.Wpf;
using Prism.Mvvm;

namespace LGU
{
    public class MenuItem : BindableBase
    {
        private string _HeaderText;
        public string HeaderText
        {
            get { return _HeaderText; }
            set { SetProperty(ref _HeaderText, value); }
        }

        private PackIconKind _Icon;
        public PackIconKind Icon
        {
            get { return _Icon; }
            set { SetProperty(ref _Icon, value); }
        }

        private string _ViewName;
        public string ViewName
        {
            get { return _ViewName; }
            set { SetProperty(ref _ViewName, value); }
        }
    }
}
