namespace BooksManagement.API.Models.ViewModels
{
    public class LoanViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public UserViewModel User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}