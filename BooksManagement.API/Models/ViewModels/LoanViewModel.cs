namespace BooksManagement.API.Models.ViewModels
{
    public class LoanViewModel
    {
        public string BookName { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}