using System.Windows.Input;
using Controller.Services;

namespace Presentation.ViewModels
{
    public class CompanyDashboardViewModel : BaseViewModel
    {
        private readonly CompanyService _companyService;

        public ICommand CreateAccountCommand { get; }
        public ICommand CreateUserCommand { get; }
        public ICommand LoadAccountCommand { get; }
        public ICommand LoadUserCommand { get; }
        public ICommand CloseCompanyCommand { get; }

        public CompanyDashboardViewModel()
        {
            _companyService = new CompanyService();
            CreateAccountCommand = new RelayCommand(OnCreateAccount);
            CreateUserCommand = new RelayCommand(OnCreateUser);
            LoadAccountCommand = new RelayCommand(OnLoadAccount);
            LoadUserCommand = new RelayCommand(OnLoadUser);
            CloseCompanyCommand = new RelayCommand(OnCloseCompany);
        }

        private void OnCreateAccount()
        {
            MainWindow.NavigateTo(new Views.CreateAccountView());
        }

        private void OnCreateUser()
        {
            MainWindow.NavigateTo(new Views.CreateUserView());
        }

        private void OnLoadAccount()
        {
            MainWindow.NavigateTo(new Views.LoadAccountView());
        }

        private void OnLoadUser()
        {
            MainWindow.NavigateTo(new Views.LoadUserView());
        }

        private void OnCloseCompany()
        {
            _companyService.Close();
            MainWindow.NavigateTo(new Views.LoadCompanyView());
        }
    }
}
