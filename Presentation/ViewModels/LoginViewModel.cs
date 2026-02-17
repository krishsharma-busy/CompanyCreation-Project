using System.Windows;
using System.Windows.Input;
using Controller.Services;
using Domain.GlobalVar;

namespace Presentation.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserService _service;

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand BackCommand { get; }

        public LoginViewModel()
        {
            _service = new UserService();
            LoginCommand = new RelayCommand(OnLogin);
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnLogin()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = _service.Authenticate(Username, Password);
            if (user != null)
            {
                MainWindow.NavigateTo(new Views.CompanyDashboardView());
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnBack()
        {
            GlobalVar.CompanyId = 0;
            MainWindow.NavigateTo(new Views.LoadCompanyView());
        }
    }
}
