using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BookShelfProject.MVVM.ViewModels
{
    public class CatalogueViewModel : ViewModelBase
    {
        public ObservableCollection<string> Categories { get; private set; }
        public ICommand _OpenSearchResultCommand { get; }

        public CatalogueViewModel()
        {
            InitializeCategories();
            _OpenSearchResultCommand = new OpenSearchResultCommand();
        }

        private void InitializeCategories()
        {
            Categories = new ObservableCollection<string>()
            {
                "Fiction",
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
    }
}
