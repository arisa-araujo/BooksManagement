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
            CreateMap<LoanInputModel, BookLoan>();
            CreateMap<BookLoan, LoanViewModel>()
                .ForMember(lvw=>lvw.StartDate, opt=>opt.MapFrom(l=>l.StartDate.ToString("dd MMMM yyyy")))
                .ForMember(lvw=>lvw.EndDate, opt=>opt.MapFrom(l=>l.EndDate.ToString("dd MMMM yyyy")))
                .ForMember(lvw=>lvw.BookName, opt=>opt.MapFrom(b=>b.Book.Title))
                .ForMember(lvw=>lvw.UserName, opt=>opt.MapFrom(b=>b.User.Name));

            
        }
    }
}