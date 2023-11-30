using BooksManagement.API.Entities;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BooksManagement.API.Models.ViewModels;
using BooksManagement.API.Models.InputModels;


namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly BooksManagementDbContext _context;

        private readonly IMapper _mapper;

        public LoansController(BooksManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loans = _context
                .BookLoans
                .Include(b => b.Book)
                .Include(u => u.User)
                .ToList();

            var viewModel = _mapper.Map<List<LoanViewModel>>(loans);

            return Ok(viewModel);
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
            
            var viewModel = _mapper.Map<LoanViewModel>(loan);

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post(LoanInputModel input)
        {
            var loan = _mapper.Map<BookLoan>(input);
        
            _context.BookLoans.Add(loan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LoanInputModel updatedLoan)
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