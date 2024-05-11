using Microsoft.AspNetCore.Components.Forms;
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
            try
            {
                user = HandleGetUser(Email);
            } catch(Exception _)
            {
                return StatusCode(500);
            }

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            try
            {
                HandleValidateUser(newUser);
                HandleCreateUser(newUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("GetUser", new { newUser.Email }, newUser);
        }

        [HttpDelete(Name = "DeleteUserByEmail")]
        public IActionResult DeleteUserByEmail(string Email)
        {
            try
            {
                HandleDeleteUser(Email);
            }
            catch (Exception _)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        /// <param name="Email"></param>
        /// <returns>User instance or null</returns>
        private User? HandleGetUser(string Email)
        {
            using (_context)
            {
                User? user = _context.Users.SingleOrDefault(u => u.Email == Email);
                return user;
            }
        }

        /// <param name="user"></param>
        /// <returns>Error string or empty string when valid</returns>
        private void HandleValidateUser(User user)
        {
            if (user.Name.IsNullOrEmpty())
            {
                throw new InvalidOperationException("User name is must be present");
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex validate = new Regex(emailPattern);
            bool validEmail = validate.IsMatch(user.Email);

            if (!validEmail)
            {
                throw new InvalidOperationException("Invalid email provided for user");
            }
        }

        /// <param name="newUser"></param>
        /// <exception cref="InvalidOperationException">If user already exists with email</exception>
        private void HandleCreateUser(User newUser)
        {
            using (_context)
            {
                User? user = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
                if (user != null)
                {
                    throw new InvalidOperationException("A user is already associated with that email");
                }

                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
        }

        /// <param name="Email"></param>
        private void HandleDeleteUser(string Email)
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
        }
    }
}
