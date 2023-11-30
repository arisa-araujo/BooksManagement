namespace BooksManagement.API.Models.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public string Isbn { get; set; }
    }
}