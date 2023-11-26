using BooksManagement.API.Entities;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly BooksManagementDbContext _context;

        public LoansController(BooksManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loans = _context
                .BookLoans
                .Include(b => b.Book)
                .Include(u => u.User)
                .ToList();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _context
                .BookLoans
                .Include(b => b.Book)
                .Include(u => u.User)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post(BookLoan loan)
        {
            _context.BookLoans.Add(loan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BookLoan updatedLoan)
        {
            var loan = _context.BookLoans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            loan.UpdateLoan(updatedLoan.BookId, updatedLoan.UserId);

            _context.BookLoans.Update(loan);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loan = _context.BookLoans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            _context.BookLoans.Remove(loan);

            _context.SaveChanges();

            return Ok();
        }
    }
}