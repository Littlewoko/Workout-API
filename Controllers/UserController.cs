using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            User? user = null;
            using (_context)
            {
                user = _context.Users.SingleOrDefault(u => u.Email == Email);
            }

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if(newUser.Name.IsNullOrEmpty())
            {
                return BadRequest("User name is must be present");
            }

            
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex validate = new Regex(emailPattern);
            bool validEmail = validate.IsMatch(newUser.Email);

            if (!validEmail)
            {
                return BadRequest("Invalid email provided for user");
            }

            using (_context)
            {
                User? user = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
                if(user != null)
                {
                    return BadRequest("A user is already associated with that email");
                }

                _context.Users.Add(newUser);
                _context.SaveChanges();
            }

            return CreatedAtRoute("GetUser", new { newUser.Email }, newUser);
        }

        [HttpDelete(Name = "DeleteUserByEmail")]
        public IActionResult DeleteUserByEmail(string Email)
        {
            using (_context)
            {
                User? user = _context.Users.SingleOrDefault(u => u.Email == Email);

                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }

            return Ok();
        }

        /*
         * Swagger won't allow two delete methods (look into?)
         */
        //[HttpDelete(Name = "DeleteUserById")]
        //public IActionResult DeleteUserById(int Id)
        //{
        //    using(_context)
        //    {
        //        User user = _context.Users.Single(u => u.Id == Id);

        //        if (user != null)
        //        {
        //            _context.Users.Remove(user);
        //            _context.SaveChanges();
        //        }
        //    }

        //    return Ok();
        //}
    }
}
