using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace BookShelf.MVVM.View
{
    /// <summary>
    /// Interaction logic for BookInfoView.xaml
    /// </summary>
    public partial class BookInfoView : UserControl
    {
        public BookInfoView()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).MainViewModel.CurrentView as BookInfoViewModel;
        }
    }
}
