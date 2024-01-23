using BookShelfProject.Core.Commands;
using BookShelfProject.Dto;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Stores
{
    public class SearchDataStore
    {
        public string SearchString { get; set; }
        public FilterType _FilterType { get; set; }
    }
}
