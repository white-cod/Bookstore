using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Dto
{
    public class DbCartDto
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
