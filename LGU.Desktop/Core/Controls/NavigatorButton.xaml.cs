using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LGU.Core.Controls
{
    /// <summary>
    /// Interaction logic for NavigatorButton.xaml
    /// </summary>
    public partial class NavigatorButton : UserControl
    {
        public NavigatorButton()
        {
            InitializeComponent();
        }

        public ICommand NavigateCommand
        {
            get => (ICommand)GetValue(NavigateCommandProperty);
            set => SetValue(NavigateCommandProperty, value);
        }
        
        public static readonly DependencyProperty NavigateCommandProperty =
            DependencyProperty.Register(nameof(NavigateCommand), typeof(ICommand), typeof(NavigatorButton), new PropertyMetadata(null));

        public object NavigateCommandParameter
        {
            get => (GetValue(NavigateCommandParameterProperty));
            set => SetValue(NavigateCommandParameterProperty, value);
        }
        
        public static readonly DependencyProperty NavigateCommandParameterProperty =
            DependencyProperty.Register(nameof(NavigateCommandParameter), typeof(object), typeof(NavigatorButton), new PropertyMetadata(null));

        public PackIconKind Icon
        {
            get => (PackIconKind)GetValue(IconProperty); set => SetValue(IconProperty, value);
        }
        
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(NavigatorButton), new PropertyMetadata(PackIconKind.Close));

        public string Caption
        {
            get => (string)GetValue(CaptionProperty); set => SetValue(CaptionProperty, value);
        }
        
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(NavigatorButton), new PropertyMetadata(null));
    }
}
