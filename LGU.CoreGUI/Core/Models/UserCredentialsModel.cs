using Prism.Mvvm;

namespace LGU.Core.Models
{
    public class UserCredentialsModel : BindableBase
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
    }
}
