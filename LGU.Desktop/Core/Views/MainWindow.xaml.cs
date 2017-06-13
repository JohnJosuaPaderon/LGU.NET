using LGU.Core.ViewModels;
using MahApps.Metro.Controls;

namespace LGU.Core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Initialize();
        }

        public MainWindowViewModel ViewModel => DataContext as MainWindowViewModel;
    }
}
