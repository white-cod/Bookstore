using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookShelf.MVVM.View
{
    /// <summary>
    /// Interaction logic for CatalogueListView.xaml
    /// </summary>
    public partial class CatalogueListView : UserControl
    {
        public ObservableCollection<string> GenresList { get; private set; }
        public ObservableCollection<string> AgesList { get; private set; }
        public CatalogueListView()
        {
            InitializeComponent();

            GenresListBox.DataContext = this;
            AgesListBox.DataContext = this;
            GenresList = new ObservableCollection<string>()
            {
                "Novel",
                "Detective",
                "Science Fiction",
                "Fantasy",
                "Horror",
                "Adventure",
                "Historical Literature",
                "Science Fiction",
                "Thriller",
                "Mystery",
                "Classic",
                "Poetry",
                "Drama",
                "Comedy",
                "Biography/Autobiography",
                "Psychological Novel",
                "Romance",
                "Youth Fantasy",
                "Popular Science Literature",
                "Documentary Prose",
                "Philosophical Literature",
                "Religious Literature",
                "Personal Development"
            };

            AgesList = new ObservableCollection<string>()
            {
                "For little children, 3+",
                "For juniors, 6+",
                "For teens, 12+",
                "For adults, 18+"
            };
        }

        
    }
}
