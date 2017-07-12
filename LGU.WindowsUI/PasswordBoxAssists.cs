using System.Windows;
using System.Windows.Controls;

namespace LGU
{
    public static class PasswordBoxAssists
    {
        public static bool GetListenPasswordChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(ListenPasswordChangedProperty);
        }

        public static void SetListenPasswordChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(ListenPasswordChangedProperty, value);
        }

        // Using a DependencyProperty as the backing store for ListenPasswordChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListenPasswordChangedProperty =
            DependencyProperty.RegisterAttached("ListenPasswordChanged", typeof(bool), typeof(PasswordBoxAssists), new PropertyMetadata(false, OnListenPasswordChanged));

        private static void OnListenPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

                if ((bool)e.NewValue)
                {
                    SetPassword(d, passwordBox.Password);
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetPassword(passwordBox, passwordBox.Password);
            }
        }

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxAssists), new PropertyMetadata(null));
    }
}
