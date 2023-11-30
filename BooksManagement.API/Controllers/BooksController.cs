using BooksManagement.API.Entities;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using BooksManagement.API.Models.ViewModels;
using BooksManagement.API.Models.InputModels;


namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManagementDbContext _context;

        private readonly IMapper _mapper;

        public BooksController(BooksManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();

            var viewModel = _mapper.Map<List<BookViewModel>>(books);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book==null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<BookViewModel>(book);

            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post(BookInputModel input)
        {
            var book = _mapper.Map<Book>(input);

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BookInputModel input)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }

            book.UpdateBook(input.Title, input.Author, input.PublicationYear, input.NumberOfPages, input.Isbn);

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