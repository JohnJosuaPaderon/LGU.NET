using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using LGU.Models.Core;
using LGU.Processes;
using LGU.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Threading.Tasks;

namespace LGU.ViewModels.Core
{
    public sealed class UserSignUpViewModel : DialogViewModelBase
    {
        private readonly IUserManager r_UserManager;

        public UserSignUpViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_UserManager = SystemRuntime.Services.GetService<IUserManager>();
            SaveCommand = new DelegateCommand(Save);
            User = new UserSignUpModel(new User());
        }

        public DelegateCommand SaveCommand { get; }

        private UserSignUpModel _User;
        public UserSignUpModel User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(User.Password))
            {
                MessageLog = "Password is invalid.";
            }
            else if (User.Password != User.ConfirmPassword)
            {
                MessageLog = "Password not matched.";
            }
            else if (await IsUsernameExistsAsync())
            {
                MessageLog = "Username already exists.";
            }
            else
            {
                var result = await r_UserManager.InsertAsync(User.GetSource());

                if (result.Status == ProcessResultStatus.Success)
                {
                    User = new UserSignUpModel(new User());
                    DialogHelper.CloseDialog();
                    ShowInfoMessage("User has been added successfully.");
                }
                else
                {
                    MessageLog = result.Message;
                }
            }
        }

        private async Task<bool> IsUsernameExistsAsync()
        {
            var result = await r_UserManager.IsUsernameExistsAsync(SecureStringConverter.Convert(User.Username));

            if (result.Status == ProcessResultStatus.Success)
            {
                return result.Data;
            }
            else
            {
                MessageLog = result.Message;
                return false;
            }
        }
    }
}
