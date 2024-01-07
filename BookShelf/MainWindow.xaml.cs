using System.Collections.ObjectModel;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookShelf.MVVM.ViewModel;
using BookShelf.Core;
using System.Reflection.Metadata;

namespace BookShelf
{
    public partial class MainWindow : Window
    {
        private TextBox SearchBox;
        private const int ELEMENTS_LIMIT = 26; // elements limit in search string
        private MainViewModel mainViewModel { get; set; }
        public ObservableCollection<string> SearchOptions { get; private set; } // is public because of binding 
        public MainWindow()
        {
            InitializeComponent();    

            mainViewModel = ((App)Application.Current).MainViewModel;
            SearchComboBox.DataContext = this;
            DataContext = mainViewModel;
            PagesHistoryManager.pagesHistory.Add(mainViewModel.CurrentView);

            SearchOptions = new ObservableCollection<string>()
            {
                "Search in books",
                "Search in authors",
                "Search in genres"
            };
        }

        private void StoreTitle_Click(object sender, RoutedEventArgs e) => HomeMenuButton.IsChecked = true; // handling a click on the title in the top menu
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox SearchBox = sender as TextBox;

            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchComboBox.IsDropDownOpen = true;
                string searchOptionsText;
                if (SearchBox.Text.Length > ELEMENTS_LIMIT) searchOptionsText = SearchBox.Text.Substring(0, ELEMENTS_LIMIT) + "..."; // if the text length is longer than the element limit, it just stops adding new elements to the searched string in the options
                else searchOptionsText = SearchBox.Text;

                SearchOptions[0] = $"Search \"{searchOptionsText}\" in books";
                SearchOptions[1] = $"Search \"{searchOptionsText}\" in authors";
                SearchOptions[2] = $"Search \"{searchOptionsText}\" in genres";

                if (this.SearchBox == null) this.SearchBox = SearchBox;
            }
            SearchComboBox.SelectedValue = string.Empty;
        }

        private void PreviousPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && PagesHistoryManager.pagesHistory.Count > 0)
            {
                int CurrentPageIndex = PagesHistoryManager.pagesHistory.IndexOf(mainViewModel.CurrentView);
                if(CurrentPageIndex > 0 && CurrentPageIndex != -1) 
                {
                    mainViewModel.CurrentView = PagesHistoryManager.pagesHistory[CurrentPageIndex - 1];

                    if (mainViewModel.CurrentView is HomeViewModel) HomeMenuButton.IsChecked = true;
                    else if (mainViewModel.CurrentView is CatalogueListViewModel) CatalogueMenuButton.IsChecked = true;
                }
            }    
        }

        private void NextPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left && PagesHistoryManager.pagesHistory.Count > 1)
            {
                int CurrentPageIndex = PagesHistoryManager.pagesHistory.IndexOf(mainViewModel.CurrentView);

                if(CurrentPageIndex < PagesHistoryManager.pagesHistory.Count-1 && CurrentPageIndex != -1) 
                {
                    mainViewModel.CurrentView = PagesHistoryManager.pagesHistory[CurrentPageIndex + 1];

                    if (mainViewModel.CurrentView is HomeViewModel) HomeMenuButton.IsChecked = true;
                    else if (mainViewModel.CurrentView is CatalogueListViewModel) CatalogueMenuButton.IsChecked = true;
                }
            }
        }

        private void SearchOption_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                TextBlock SelectedSearchOption = sender as TextBlock;
                if (SelectedSearchOption != null && SearchBox.Text != null)
                {
                    string SelectedOptionText = SelectedSearchOption.Text;
                    SearchType parameter = (SearchType)SearchOptions.IndexOf(SelectedOptionText);
                    SearchManager.Search(parameter, SearchBox.Text);
                    SearchBox.Text = string.Empty;
                }
            }            
        }

        private void SearchImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!string.IsNullOrEmpty(SearchBox.Text) && e.ChangedButton == MouseButton.Left)
            {
                SearchManager.Search(SearchType.Title, SearchBox.Text);
                SearchBox.Text = string.Empty;           
            }
        }

        private void ProfileOpen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                // your code here
            }
        }
    }
}