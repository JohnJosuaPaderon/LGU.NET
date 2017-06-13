using LGU.Core.Models;
using Prism.Mvvm;

namespace LGU.Core.ViewModels
{
    public class UserLoginViewModel : BindableBase
    {
        public UserLoginViewModel()
        {

        }

        private UserCredentialsModel _UserCredentials;
        public UserCredentialsModel UserCredentials
        {
            get { return _UserCredentials; }
            set { SetProperty(ref _UserCredentials, value); }
        }
    }
}
