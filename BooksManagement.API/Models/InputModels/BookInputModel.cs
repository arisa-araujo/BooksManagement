namespace BooksManagement.API.Models.InputModels
{
    public class BookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public string Isbn { get; set; }
    }
}