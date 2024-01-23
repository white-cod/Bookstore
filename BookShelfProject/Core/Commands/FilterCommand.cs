using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public enum FilterType
    {
        All = 0,
        Book,
        Author,
        Genre
    }

    public class FilterCommand : CommandBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        private readonly FilterType _filterType;
        private readonly SearchDataStore _searchDataStore;
        private readonly SearchResultViewModel _currentViewModel;

        public FilterCommand(FilterType filterType, SearchDataStore searchDataStore, SearchResultViewModel currentViewModel)
        {
            _filterType = filterType;
            _searchDataStore = searchDataStore;
            _context = ServiceLocator.GetService<DatabaseContext>();
            _mapper = ServiceLocator.GetService<IMapper>();
            _currentViewModel = currentViewModel;
        }

        public override void Execute(object? parameter)
        {
            switch (_filterType)
            {
                case FilterType.All:
                    var booksByTitle = _mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Title.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList());
                    var booksByAuthor = _mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Author.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList());
                    var booksByGenre = _mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Genre.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList());

                    var generalList = booksByTitle.Concat(booksByAuthor).Concat(booksByGenre).Distinct().ToList();
                  
                    _currentViewModel.ResultsList = new ObservableCollection<ListBookDto>(generalList);
                    break;

                case FilterType.Book:
                    _currentViewModel.ResultsList = new ObservableCollection<ListBookDto>(_mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Title.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList()));
                    break;

                case FilterType.Author:
                    _currentViewModel.ResultsList = new ObservableCollection<ListBookDto>(_mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Author.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList()));
                    break;

                case FilterType.Genre:
                    _currentViewModel.ResultsList = new ObservableCollection<ListBookDto>(_mapper.Map<List<ListBookDto>>(_context.Books.Where(x => x.Genre.ToLower().Contains(_searchDataStore.SearchString.ToLower())).ToList()));
                    break;

                default:
                    MessageBox.Show($"Неизвестный тип фильтрации: {_filterType}");
                    return;
            }
            _currentViewModel._FilterType = _filterType;
        }
    }
}
