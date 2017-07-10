using LGU.ViewModels.HumanResource;
using System.Windows.Controls;

namespace LGU.Views.HumanResource
{
    /// <summary>
    /// Interaction logic for PreviewDepartmentView
    /// </summary>
    public partial class PreviewDepartmentView : UserControl
    {
        public PreviewDepartmentView()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Initialize();
        }

        public PreviewDepartmentViewModel ViewModel => DataContext as PreviewDepartmentViewModel;
    }
}
