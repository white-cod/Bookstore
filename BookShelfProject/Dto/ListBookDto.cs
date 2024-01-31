using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookShelfProject.Dto
{
    public class ListBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal SalePrice { get; set; } 
        public decimal CostPrice { get; set; }
        public bool IsDiscount { get;set; }
        public string CoverPath { get; set; }
    }
}
