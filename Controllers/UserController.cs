using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Workout_API.DBContexts;
using Workout_API.Models;

namespace Workout_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DBContext _context;

        public UserController(DBContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUser")]
        public IActionResult Get(string Email)
        {
            User user = null;
            using (_context)
            {
                user = _context.Users.Single(u => u.Email == Email);
            }

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex validate = new Regex(emailPattern);
            bool validEmail = validate.IsMatch(newUser.Email);

            if (!validEmail)
            {
                return BadRequest("Invalid email provided for user");
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { Email = newUser.Email }, newUser);
        }

        [HttpPost(Name = "DeleteUserByEmail")]
        public IActionResult DeleteUser(string Email)
        {
            User user = _context.Users.Single(u => u.Email == Email);

            if (user == null)
            {
                return Ok();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost(Name = "DeleteUserById")]
        public IActionResult DeleteUser(int Id)
        {
            User user = _context.Users.Single(u => u.Id == Id);

            if (user == null)
            {
                return Ok();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
