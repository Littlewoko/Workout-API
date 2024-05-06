using Microsoft.AspNetCore.Mvc;
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

            if(user == null)
            {
                return NotFound();
            } else
            {
                return Ok(user);
            }
        }
    }
}
