using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Stores
{
    public class CurrentUserDataStore
    {
        public User CurrentUser { get; set; }
        public bool IsLogin { get; private set; } = false;
        public void LoginUser()
        {
            IsLogin = true;
        }
        public void LogoutUser()
        {
            IsLogin = false;
            CurrentUser = null;
        }
    }
}
