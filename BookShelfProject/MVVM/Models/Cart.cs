using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.MVVM.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book _Book { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User _User { get; set; }
        public int Quantity { get; set; }
    }
}
