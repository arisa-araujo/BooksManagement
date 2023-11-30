using AutoMapper;
using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Models.ViewModels;

namespace BooksManagement.API.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookInputModel, Book>();
        }
    }
}