using System.Collections.ObjectModel;
using System.Windows.Input;
using Controller.Services;
using Domain.DTO;

namespace Presentation.ViewModels
{
    public class LoadUserViewModel : BaseViewModel
    {
        private readonly UserService _service;
        public ObservableCollection<UserDTO> Users { get; set; }

        public ICommand BackCommand { get; }

        public LoadUserViewModel()
        {
            _service = new UserService();
            Users = new ObservableCollection<UserDTO>();
            BackCommand = new RelayCommand(OnBack);
            LoadUsers();
        }

        private void LoadUsers()
        {
            Users.Clear();
            var list = _service.ListUsers();
            foreach (var user in list)
            {
                Users.Add(user);
            }
        }

        private void OnBack()
        {
            MainWindow.NavigateTo(new Views.CompanyDashboardView());
        }
    }
}
