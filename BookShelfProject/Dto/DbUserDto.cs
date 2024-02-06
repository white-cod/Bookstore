using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Dto
{
    public class DbUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsAdmin { get; set; }
        public string? Name { get; set; }
    }
}