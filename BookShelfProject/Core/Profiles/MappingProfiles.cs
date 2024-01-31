using AutoMapper;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookShelfProject.Core.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, ListBookDto>();
            CreateMap<ListBookDto, Book>();

            CreateMap<Book, DbBookDto>();
            CreateMap<DbBookDto, Book>();

            CreateMap<User, DbUserDto>();
            CreateMap<DbUserDto, User>();

            CreateMap<Cart, DbCartDto>();
            CreateMap<DbCartDto, Cart>();
        }
    }

}
