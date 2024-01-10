using BookShelf.Core.Managers;
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
        public ObservableCollection<string> GenresCategoriesList { get; private set; }
        public CatalogueListView()
        {
            InitializeComponent();

            GenresCategoriesListBox.DataContext = this;
            GenresCategoriesList = new ObservableCollection<string>()
            {
                "Science Fiction",
                "Fantasy",
                "Detective",
                "Thriller",
                "Romance",
                "Adventure",
                "Drama",
                "Comedy",
                "Horror",
                "Historical Fiction",
                "Science Fiction",
                "Mystery",
                "Religious Literature",
                "Philosophy",
                "Psychology",
                "Romantic Novel",
                "Memoirs",
                "Biography",
                "Poetry",
                "Classic",
                "Contemporary Literature",
                "Non-Fiction",
                "Children's Literature",
                "Young Adult Literature",
                "Folklore",
                "Popular Science",
                "Travel Guides",
                "Culinary",
                "Art and Photography",
                "Business and Economics",
                "Sports",
                "Science and Education",
                "Technology and Computers",
                "Politics and Social Sciences",
                "Esotericism and Occultism",
                "Music",
                "Coming-of-age",
                "Humor",
                "Dystopian",
                "Self-Development",
                "Ecology and Nature",
                "Military Literature",
                "Fantasy for Children",
                "Adventure for Children",
                "Science Fiction for Teens",
                "Software Development",
                "Autobiography",
                "Collecting and Antiques",
                "Finance and Investments",
                "Painting and Crafts"
            };
        }

        private void ElementClick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left && sender != null)
            {
                var clicked_block = sender as TextBlock;
                if(!string.IsNullOrEmpty(clicked_block.Text))
                {
                    SearchManager.Search(SearchType.Genre, clicked_block.Text);
                }
            }
        }
    }
}
