using LGU.ViewModels.HumanResource;
using System.Windows.Controls;

namespace LGU.Views.HumanResource
{
    /// <summary>
    /// Interaction logic for DepartmentManagementView
    /// </summary>
    public partial class DepartmentManagementView : UserControl
    {
        public DepartmentManagementView()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Initialize();
        }

        public DepartmentManagementViewModel ViewModel => DataContext as DepartmentManagementViewModel;
    }
}
