using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class OpenBookPageCommand : CommandBase
    { 
        public override void Execute(object? parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("Not Found.");
                return;
            }
            var _mapper = ServiceLocator.GetService<IMapper>();
            var _context = ServiceLocator.GetService<DatabaseContext>();

            var title = ((ListBookDto)parameter).Title;

            var book = _context.Books.FirstOrDefault(x => x.Title == title);
            if (book != null)
            {
                ServiceLocator.GetService<CurrentBookDataStore>().CurrentBook = book;

                var bookPageNavigationService = ServiceLocator.GetService<INavigationService<BookPageViewModel>>();

                var navigateCommand = new NavigateCommand<BookPageViewModel>(bookPageNavigationService);
                navigateCommand.Execute(null);
            }
            else
            {
                MessageBox.Show($"Book with {title} not found.");
            }
            

        }
    }
}
