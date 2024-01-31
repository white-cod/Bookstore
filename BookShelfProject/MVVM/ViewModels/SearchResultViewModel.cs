using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.Models;
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
    public class SearchResultViewModel : ViewModelBase
    {
        private readonly SearchDataStore _searchDataStore;
        private ObservableCollection<ListBookDto> _resultsList;

        public ObservableCollection<ListBookDto> ResultsList
        {
            get
            {
                return _resultsList;
            }
            set
            {
                _resultsList = value;
                OnPropertyChanged(nameof(ResultsList));
            }
        }

        public FilterType _FilterType
        {
            get => _searchDataStore._FilterType;
            set
            {
                _searchDataStore._FilterType = value;
                OnPropertyChanged(nameof(_FilterType));
            }
        }

        public ICommand FilterAllCommand { get; }
        public ICommand FilterByTitleCommand { get; }
        public ICommand FilterByAuthorCommand { get; }
        public ICommand FilterByGenreCommand { get; }
        public ICommand _OpenBookPageCommand { get; }

        public SearchResultViewModel()
        {
            _searchDataStore = ServiceLocator.GetService<SearchDataStore>();

            ResultsList = new ObservableCollection<ListBookDto>();

            _OpenBookPageCommand = new OpenBookPageCommand();

            FilterAllCommand = new FilterCommand(FilterType.All, _searchDataStore, this);
            FilterByTitleCommand = new FilterCommand(FilterType.Book, _searchDataStore, this);
            FilterByAuthorCommand = new FilterCommand(FilterType.Author, _searchDataStore, this);
            FilterByGenreCommand = new FilterCommand(FilterType.Genre, _searchDataStore, this);

            FilterAllCommand.Execute(null);
        }
    }
}
