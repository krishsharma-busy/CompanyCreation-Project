using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;
using Domain.GlobalVar;

namespace Presentation.ViewModels
{
    public class LoadCompanyViewModel : BaseViewModel
    {
        private readonly CompanyService _companyService;
        private readonly UserService _userService;

        public ObservableCollection<CompanyDTO> Companies { get; set; }

        private CompanyDTO _selectedCompany;
        public CompanyDTO SelectedCompany
        {
            get => _selectedCompany;
            set => SetProperty(ref _selectedCompany, value);
        }

        public ICommand OpenCommand { get; }
        public ICommand BackCommand { get; }

        public LoadCompanyViewModel()
        {
            _companyService = new CompanyService();
            _userService = new UserService();
            Companies = new ObservableCollection<CompanyDTO>();
            OpenCommand = new RelayCommand(OnOpen);
            BackCommand = new RelayCommand(OnBack);
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            Companies.Clear();
            var list = _companyService.ListCompanies();
            foreach (var company in list)
            {
                Companies.Add(company);
            }
        }

        private void OnOpen()
        {
            if (SelectedCompany == null)
            {
                MessageBox.Show("Please select a company.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GlobalVar.CompanyId = SelectedCompany.Id;

            if (_userService.CheckIfUserExists())
            {
                MainWindow.NavigateTo(new Views.LoginView());
            }
            else
            {
                MainWindow.NavigateTo(new Views.CompanyDashboardView());
            }
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.MainMenuView());
        }
    }
}
