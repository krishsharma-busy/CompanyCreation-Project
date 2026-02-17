using System.Windows;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;

namespace Presentation.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        private readonly UserService _service;

        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _password = "";
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public CreateUserViewModel()
        {
            _service = new UserService();
            SaveCommand = new RelayCommand(OnSave);
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnSave()
        {
            // Required fields
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dto = new UserDTO
            {
                Id = 0,
                Name = (Name ?? "").Trim(),
                Password = (Password ?? "").Trim()
            };

            _service.Save(dto);
            MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }
    }
}
