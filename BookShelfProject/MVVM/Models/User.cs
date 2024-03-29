﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.MVVM.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Cart> _ShoppingCart { get; set; }
    }
}
