using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using BookShelf.Core;

namespace BookShelf.MVVM.Model
{
    public class Book : ObservableObject
    {
        public string title { get; set; }
        public string author {  get; set; }
        public string publisher { get; set; }
        public int? pages { get; set; }
        public string genre { get; set; }
        public int? publication_year { get; set; }
        public decimal? cost_price { get; set; }
        public decimal? sale_price { get; set; }
        public int? continuation_of { get; set; }       
        public string? summary { get; set; }
        public BitmapImage cover { get; set; }

        public Book(string title, string author, string publisher, int? pages, string genre, int? publication_year, decimal? cost_price, decimal? sale_price, int? continuation_of, string? summary_path, string? cover_path)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.pages = pages;
            this.genre = genre;
            this.publication_year = publication_year;
            this.cost_price = cost_price;
            this.sale_price = sale_price;
            this.continuation_of = continuation_of;

            if (!string.IsNullOrEmpty(cover_path) && File.Exists(cover_path))
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(cover_path));
                cover = bitmapImage;
            }
            else cover = null;

            if (!string.IsNullOrEmpty(summary_path) && File.Exists(summary_path))
            {
                string summaryText = File.ReadAllText(summary_path);
                summary = summaryText;
            }
            else
            {
                summary = "No summary available.";
            }
        }
    }
}
