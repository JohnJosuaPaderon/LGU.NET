using Prism.Mvvm;

namespace LGU.Interactivity
{
    public class CustomNotification : BindableBase, ICustomNotification
    {
        public CustomNotification()
        {
            Title = string.Empty;
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private object _Content;
        public object Content
        {
            get { return _Content; }
            set { SetProperty(ref _Content, value); }
        }
    }
}
