using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using Workout_API.DBContexts;
using Workout_API.Models;
using Workout_API.Utils;

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
                user = UserUtils.HandleGetUser(_context, Email);
            }
            catch (Exception)
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

        [HttpPut(Name = "UpdateUser")]
        public IActionResult UpdateUser([FromBody] User updatedUser)
        {
            try
            {
                HandleValidateUser(updatedUser);

                User? user = UserUtils.HandleGetUser(_context, updatedUser.Email);
                if (user == null)
                    throw new InvalidOperationException("The user you have attempted to update does not exist");
                else
                    HandleUpdateUser(user, updatedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete(Name = "DeleteUserByEmail")]
        public IActionResult DeleteUserByEmail(string Email)
        {
            try
            {
                User? user = UserUtils.HandleGetUser(_context, Email);
                HandleDeleteUser(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        private static void HandleValidateUser(User user)
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

        private void HandleCreateUser(User newUser)
        {
            User? user = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
            if (user != null)
            {
                throw new InvalidOperationException("A user is already associated with that email");
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void HandleUpdateUser(User user, User updatedUser)
        {
            user.Name = updatedUser.Name;
            
            _context.SaveChanges();
        }

        private void HandleDeleteUser(User? user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
