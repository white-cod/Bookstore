using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.ViewModels;
using BookShelfProject.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookShelfProject.Core.Commands
{
    public class OpenEditBookWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter == null) return;
         
            var context = ServiceLocator.GetService<DatabaseContext>();
            var mapper = ServiceLocator.GetService<IMapper>();
            ListBookDto listDb = (parameter  as ListBookDto);

            if (listDb == null) return;

            var bookDb = context.Books.Where(b => b.BookId == listDb.BookId).FirstOrDefault();

            if (bookDb == null) return;

            ServiceLocator.GetService<SelectedBookToEditStore>().CurrentBook = bookDb;

            var window = ServiceLocator.GetService<EditBookWindow>();

            window = new EditBookWindow()
            {
                DataContext = ServiceLocator.GetService<EditBookViewModel>(),
            };

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            window.Show();
            foreach (Window w in Application.Current.Windows)
            {
                if (w != window)
                    w.Close();
            }
        }
    }
}
