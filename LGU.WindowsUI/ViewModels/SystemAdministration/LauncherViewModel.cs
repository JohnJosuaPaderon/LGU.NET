﻿using LGU.Utilities;
using LGU.Views.SystemAdministration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.SystemAdministration
{
    public class LauncherViewModel : ViewModelBase
    {
        private readonly ISystemAdministratorManager SystemAdministratorManager;

        public LauncherViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            SystemAdministratorManager = SystemRuntime.Services.GetService<ISystemAdministratorManager>();
            VerifyCommand = new DelegateCommand(Verify);
            Initialize();
        }

        public DelegateCommand VerifyCommand { get; }

        private string _AdministratorKey;
        public string AdministratorKey
        {
            get { return _AdministratorKey; }
            set { SetProperty(ref _AdministratorKey, value); }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }

        private void Verify()
        {
            if (!string.IsNullOrWhiteSpace(AdministratorKey))
            {
                if (AdministratorKey == "@@RESET")
                {
                    SystemAdministratorManager.GenerateAdministratorKey();
                    AdministratorKey = string.Empty;
                }
                else
                {
                    var result = SystemAdministratorManager.Verify(SecureStringConverter.ConvertToSecureString(AdministratorKey));

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        RegionManager.RequestNavigate(MainWindowViewModel.MainContentRegionName, nameof(MainView));
                    }
                    else
                    {
                        Message = result.Message;
                    }
                }
            }
            else
            {
                Message = "Invalid administrator's key.";
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
