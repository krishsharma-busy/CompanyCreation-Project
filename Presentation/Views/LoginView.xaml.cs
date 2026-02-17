using System.Windows;
using System.Windows.Controls;

namespace Presentation.Views
{
    public partial class LoginView : UserControl
    {
        private bool _isPasswordVisible = false;

        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!_isPasswordVisible)
            {
                if (DataContext is ViewModels.LoginViewModel vm)
                {
                    vm.Password = PasswordBox.Password;
                }
                // Sync visible box if we are typing in hidden box
                if (VisiblePasswordBox.Text != PasswordBox.Password)
                {
                    VisiblePasswordBox.Text = PasswordBox.Password;
                }
            }
        }

        private void VisiblePasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isPasswordVisible)
            {
                if (DataContext is ViewModels.LoginViewModel vm)
                {
                    vm.Password = VisiblePasswordBox.Text;
                }
                // Sync hidden box if we are typing in visible box
                if (PasswordBox.Password != VisiblePasswordBox.Text)
                {
                    PasswordBox.Password = VisiblePasswordBox.Text;
                }
            }
        }

        private void TogglePassword_Click(object sender, RoutedEventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible)
            {
                // Show visible box, hide password box
                VisiblePasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Text = PasswordBox.Password;
                TogglePasswordButton.Content = "🔒"; // Change icon to indicate "hide"
            }
            else
            {
                // Show password box, hide visible box
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Password = VisiblePasswordBox.Text;
                TogglePasswordButton.Content = "👁"; // Change icon to indicate "show"
            }
        }
    }
}
