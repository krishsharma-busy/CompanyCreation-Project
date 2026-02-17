using System.Linq;
using System.Windows;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;

namespace Presentation.ViewModels
{
    public class CreateCompanyViewModel : BaseViewModel
    {
        private readonly CompanyService _service;

        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _gstin = "";
        public string Gstin
        {
            get => _gstin;
            set => SetProperty(ref _gstin, value);
        }

        private string _country = "";
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private string _state = "";
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public CreateCompanyViewModel()
        {
            _service = new CompanyService();
            SaveCommand = new RelayCommand(OnSave);
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnSave()
        {
            // Required field
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Company Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // GSTIN: must be exactly 15 alphanumeric characters (letters and digits only)
            if (!string.IsNullOrEmpty(Gstin))
            {
                if (Gstin.Length != 15)
                {
                    MessageBox.Show("GSTIN must be exactly 15 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!Gstin.All(char.IsLetterOrDigit))
                {
                    MessageBox.Show("GSTIN must contain only letters and numbers.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Country: letters and spaces only
            if (!string.IsNullOrEmpty(Country) && !Country.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Country must contain only letters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // State: letters and spaces only
            if (!string.IsNullOrEmpty(State) && !State.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("State must contain only letters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // GSTIN uniqueness check
            if (!string.IsNullOrEmpty(Gstin) && !_service.IsGstinUnique(Gstin))
            {
                MessageBox.Show("A company with this GSTIN already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dto = new CompanyDTO
            {
                Id = 0,
                Name = (Name ?? "").Trim(),
                Gstin = (Gstin ?? "").Trim(),
                Country = (Country ?? "").Trim(),
                State = (State ?? "").Trim()
            };

            _service.Save(dto);
            MessageBox.Show("Company saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow.NavigateTo(new Views.MainMenuView());
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.MainMenuView());
        }
    }
}
