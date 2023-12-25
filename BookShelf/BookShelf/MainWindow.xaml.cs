using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookShelf.MVVM.ViewModel;

namespace BookShelf
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel; 
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = ((App)Application.Current).MainViewModel;
            DataContext = mainViewModel;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainViewModel.CurrentView = new HomeViewModel();
        }
        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}