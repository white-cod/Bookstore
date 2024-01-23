using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.MVVM.ViewModels
{
    public class BookPageViewModel : ViewModelBase
    {
        public CurrentBookDataStore _CurrentBookDataStore { get; }
        public BookPageViewModel()
        {
            _CurrentBookDataStore = ServiceLocator.GetService<CurrentBookDataStore>();
        }
    }
}
