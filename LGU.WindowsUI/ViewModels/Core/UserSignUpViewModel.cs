using LGU.EntityManagers.Core;
using LGU.Models.Core;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.Core
{
    public sealed class UserSignUpViewModel : ViewModelBase
    {
        private readonly IUserManager UserManager;

        public UserSignUpViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            UserManager = SystemRuntime.Services.GetService<IUserManager>();
            SaveCommand = new DelegateCommand(Save);
        }

        public DelegateCommand SaveCommand { get; }

        private UserSignUpModel _User;
        public UserSignUpModel User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }

        private void Save()
        {
        }
    }
}
