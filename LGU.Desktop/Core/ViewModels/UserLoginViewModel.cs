using Prism.Commands;
using Prism.Mvvm;
using LGU.Core.Models;
using Prism.Regions;

namespace LGU.Core.ViewModels
{
    internal class UserLoginViewModel : BindableBase
    {
        public UserLoginViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            UserLoginCredentials = new UserLoginCredentials();
        }

        private IRegionManager RegionManager { get; }

        private DelegateCommand _SignInCommand;
        public DelegateCommand SignInCommand =>
            _SignInCommand ?? (_SignInCommand = new DelegateCommand(SignIn));

        private UserLoginCredentials _UserLoginCredentials;
        public UserLoginCredentials UserLoginCredentials
        {
            get { return _UserLoginCredentials; }
            set { SetProperty(ref _UserLoginCredentials, value); }
        }

        private void SignIn()
        {
            RegionManager.RequestNavigate(MainWindowViewModel.CONTENT_REGION, MainWindowViewModel.ContentRegionMainTarget);
        }
    }
}
