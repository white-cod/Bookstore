using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Stores
{
    public class CurrentBookDataStore
    {
        public Book CurrentBook { get; set; }
        public CurrentBookDataStore()
        {

        }
    }
}
