using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ObservableCollection<ListBookDto> RecommendedBooks { get; }
        public ObservableCollection<ListBookDto> NewBooks { get; }
        public ObservableCollection<ListBookDto> OfferedBooks { get; }
        public ICommand _OpenBookPageCommand { get; }
        public HomeViewModel()
        {
            try
            {
                _context = ServiceLocator.GetService<DatabaseContext>();
                _mapper = ServiceLocator.GetService<IMapper>();

                _OpenBookPageCommand = new OpenBookPageCommand();
                
                RecommendedBooks = GetRecommendedBooks();
                NewBooks = GetNewBooks();
                OfferedBooks = GetOfferedBooks();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ObservableCollection<ListBookDto> GetRecommendedBooks()
        {
            var recommendedBooks = _context.Books.Where(b => b.IsRecommended == true)
                                                 .ToList();

            var mappedBooks = _mapper.Map<List<ListBookDto>>(recommendedBooks[0..5]);

            return new ObservableCollection<ListBookDto>(mappedBooks);
        }
        private ObservableCollection<ListBookDto> GetNewBooks()
        {
            var newBooks = _context.Books.ToList();

            var mappedBooks = _mapper.Map<List<ListBookDto>>(newBooks[7..12]);

            return new ObservableCollection<ListBookDto>(mappedBooks);
        }
        private ObservableCollection<ListBookDto> GetOfferedBooks()
        {
            var newBooks = _context.Books.Where(b=>b.IsDiscount == true)
                                         .ToList();

            var mappedBooks = _mapper.Map<List<ListBookDto>>(newBooks[0..5]);

            return new ObservableCollection<ListBookDto>(mappedBooks);
        }
    }
}
