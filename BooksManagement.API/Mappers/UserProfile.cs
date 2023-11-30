using AutoMapper;
using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Models.ViewModels;

namespace BooksManagement.API.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserInputModel, User>();
        }
    }
}