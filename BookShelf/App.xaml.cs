using BookShelf.Core;
using BookShelf.MVVM.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BookShelf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainViewModel MainViewModel { get; } = new MainViewModel();
    }

}
