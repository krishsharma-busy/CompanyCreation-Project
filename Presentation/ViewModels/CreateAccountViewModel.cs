using System.Linq;
using System.Windows;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;

namespace Presentation.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        private readonly AccountService _service;

        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _group = "";
        public string Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        private string _balanceText = "";
        public string BalanceText
        {
            get => _balanceText;
            set => SetProperty(ref _balanceText, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public CreateAccountViewModel()
        {
            _service = new AccountService();
            SaveCommand = new RelayCommand(OnSave);
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnSave()
        {
            // Required field
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Account Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Balance: must be a valid number (digits, decimal point, optional minus sign)
            decimal balance = 0;
            if (!string.IsNullOrEmpty(BalanceText))
            {
                if (!decimal.TryParse(BalanceText, out balance))
                {
                    MessageBox.Show("Balance must be a valid number. Letters and special characters are not allowed.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Account name uniqueness check within the company
            if (!_service.IsAccountNameUnique(Name))
            {
                MessageBox.Show("An account with this name already exists in this company.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dto = new AccountDTO
            {
                Id = 0,
                Name = (Name ?? "").Trim(),
                Group = (Group ?? "").Trim(),
                Balance = balance
            };

            _service.Save(dto);
            MessageBox.Show("Account created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }
    }
}
