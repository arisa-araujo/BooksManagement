namespace BooksManagement.API.Entities
{
    public class Book
    {
        public Book(string title, string author, int publicationYear, int numberOfPages, string isbn)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            NumberOfPages = numberOfPages;
            Isbn = isbn;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public string Isbn { get; set; }

        public void UpdateBook(string title, string author, int publicationYear, int numberOfPages, string isbn)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            NumberOfPages = numberOfPages;
            Isbn = isbn;
        }
    }
}