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
    public class UsersController : ControllerBase
    {
        private readonly BooksManagementDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(BooksManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();

            var viewModel = _mapper.Map<List<UserViewModel>>(users);

            return Ok(viewModel);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<UserViewModel>(user);

            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post(UserInputModel input)
        {
            var user = _mapper.Map<User>(input);

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserInputModel updatedUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UpdateUser(updatedUser.Name, updatedUser.Email);

            _context.Users.Update(user);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            _context.SaveChanges();

            return Ok();
        }
    }
}