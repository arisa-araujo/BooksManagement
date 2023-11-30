using System;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Entities
{
    public class BookLoan
    {
        public BookLoan(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; } 
        public int BookId { get; set; }
        [JsonIgnore]
        public Book? Book { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        public DateTime EndDate { get; set; } = DateTime.Now.Date.AddDays(7);

        public void UpdateLoan(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}