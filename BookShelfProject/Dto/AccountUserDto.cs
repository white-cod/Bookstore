﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Dto
{
    public class AccountUserDto
    {
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
    }
}
