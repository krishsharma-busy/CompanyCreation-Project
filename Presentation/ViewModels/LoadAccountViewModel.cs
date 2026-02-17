using System.Collections.ObjectModel;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;

namespace Presentation.ViewModels
{
    public class LoadAccountViewModel : BaseViewModel
    {
        private readonly AccountService _service;
        private readonly UserService _userService;
        public ObservableCollection<AccountDTO> Accounts { get; set; }

        public ICommand BackCommand { get; }

        public LoadAccountViewModel()
        {
            _service = new AccountService();
            _userService = new UserService();
            Accounts = new ObservableCollection<AccountDTO>();
            BackCommand = new RelayCommand(OnBack);
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            Accounts.Clear();

            System.Collections.Generic.List<AccountDTO> list;

            if (_userService.CheckIfUserExists())
            {
                // Users exist → show only current user's accounts
                list = _service.ListAccounts();
            }
            else
            {
                // No users exist → show all accounts for company
                list = _service.ListAllAccounts();
            }

            foreach (var account in list)
            {
                Accounts.Add(account);
            }
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }
    }
}
