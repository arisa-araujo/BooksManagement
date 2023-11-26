using BooksManagement.API.Entities;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManagementDbContext _context;

        public BooksController(BooksManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }

            book.UpdateBook(updatedBook.Title, updatedBook.Author, updatedBook.PublicationYear, updatedBook.NumberOfPages, updatedBook.Isbn);

            _context.Books.Update(book);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if(book==null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);

            _context.SaveChanges();

            return Ok();
        }
    }
}