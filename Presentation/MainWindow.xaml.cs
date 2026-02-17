using System.Windows;
using System.Windows.Controls;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
            NavigateTo(new Views.MainMenuView());
        }

        public static void NavigateTo(UserControl view)
        {
            if (_instance != null)
            {
                _instance.MainContent.Content = view;
            }
        }
    }
}
