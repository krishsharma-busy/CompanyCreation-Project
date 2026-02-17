using System.Windows;
using System.Windows.Controls;

namespace Presentation.Views
{
    public partial class CreateUserView : UserControl
    {
        private bool _isPasswordVisible = false;

        public CreateUserView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!_isPasswordVisible)
            {
                if (DataContext is ViewModels.CreateUserViewModel vm)
                {
                    vm.Password = PasswordBox.Password;
                }
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
                if (DataContext is ViewModels.CreateUserViewModel vm)
                {
                    vm.Password = VisiblePasswordBox.Text;
                }
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
                VisiblePasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Text = PasswordBox.Password;
                TogglePasswordButton.Content = "🔒";
            }
            else
            {
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Password = VisiblePasswordBox.Text;
                TogglePasswordButton.Content = "👁";
            }
        }
    }
}
