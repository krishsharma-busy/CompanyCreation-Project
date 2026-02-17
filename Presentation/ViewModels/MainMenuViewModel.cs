using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public ICommand CreateCompanyCommand { get; }
        public ICommand LoadCompanyCommand { get; }

        public MainMenuViewModel()
        {
            CreateCompanyCommand = new RelayCommand(OnCreateCompany);
            LoadCompanyCommand = new RelayCommand(OnLoadCompany);
        }

        private void OnCreateCompany()
        {
            MainWindow.NavigateTo(new Views.CreateCompanyView());
        }

        private void OnLoadCompany()
        {
            MainWindow.NavigateTo(new Views.LoadCompanyView());
        }
    }
}
