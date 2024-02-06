using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelf.MVVM.Model;

namespace BookShelf.Core.Managers
{
    public static class BookDataManager // Support class-storage for the current selected book data
    {
        public static Book BookData { get; set; }
    }
}
