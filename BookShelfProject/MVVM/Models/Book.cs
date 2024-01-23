using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.MVVM.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int? ContinuationOf { get; set; }
        public string? CoverPath { get; set; }
        public string? SummaryPath { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsDiscount { get; set; }
    }
}
