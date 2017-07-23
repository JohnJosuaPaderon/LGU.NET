using LGU.Models.SystemAdministration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LGU.ViewModels.SystemAdministration
{
    public sealed class ConnectionStringSourceViewModel : ViewModelBase
    {
        private readonly IConnectionStringSource r_ConnectionStringSource;

        public ConnectionStringSourceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_ConnectionStringSource = SystemRuntime.Services.GetService<IConnectionStringSource>();
            LoadCommand = new DelegateCommand(Initialize);
            SaveCommand = new DelegateCommand(Save);
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
        }

        public ObservableCollection<ConnectionStringModel> ConnectionStrings { get; } = new ObservableCollection<ConnectionStringModel>();

        public DelegateCommand LoadCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand RemoveCommand { get; }

        private ConnectionStringModel _SelectedConnectionString;
        public ConnectionStringModel SelectedConnectionString
        {
            get { return _SelectedConnectionString; }
            set { SetProperty(ref _SelectedConnectionString, value); }
        }

        private bool _IsEncrypted;
        public bool IsEncrypted
        {
            get { return _IsEncrypted; }
            set { SetProperty(ref _IsEncrypted, value); }
        }

        public override void Initialize()
        {
            base.Initialize();

            var connectionStrings = r_ConnectionStringSource.GetSource();
            IsEncrypted = r_ConnectionStringSource.IsEncrypted;

            foreach (var connectionString in connectionStrings)
            {
                ConnectionStrings.Add(new ConnectionStringModel(connectionString));
            }
        }

        private void Save()
        {
            var list = new List<ConnectionString>();

            foreach (var item in ConnectionStrings)
            {
                list.Add(item.GetSource());
            }

            r_ConnectionStringSource.Overwrite(IsEncrypted, list);
        }

        private void Add()
        {
            ConnectionStrings.Add(new ConnectionStringModel(new ConnectionString() { Key = "_KEY" }));
        }

        private void Remove()
        {
            ConnectionStrings.Remove(SelectedConnectionString);
        }
    }
}
