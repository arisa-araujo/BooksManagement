using AutoMapper;
using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Models.ViewModels;

namespace BooksManagement.API.Mappers
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<BookLoan, LoanViewModel>();
            CreateMap<LoanInputModel, BookLoan>();
        }
    }
}