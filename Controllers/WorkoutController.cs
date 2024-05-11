using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Workout_API.DBContexts;
using Workout_API.Models;

namespace Workout_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : Controller
    {
        private DBContext _context;
        public WorkoutController(DBContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllWorkouts")]
        public IActionResult Get()
        {
            List<Workout> workouts = new List<Workout>();
            if (!_context.Workouts.Any())
            {
                return NoContent();
            }

            workouts = _context.Workouts.ToList();

            return Ok(workouts);
        }

        [HttpGet("getById/{id}", Name = "GetWorkoutById")]
        public IActionResult GetById(int Id)
        {
            Workout? workout = null;
            workout = _context.Workouts.SingleOrDefault(u => u.Id == Id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost(Name = "CreateWorkout")]
        public IActionResult CreateWorkout([FromBody] Workout newWorkout)
        {
            User? user = _context.Users.SingleOrDefault(u => u.Id == newWorkout.User.Id || u.Email == newWorkout.User.Email);

            if (user == null)
            {
                return BadRequest("Provided user does not exist");

            }

            newWorkout.User = user;

            _context.Workouts.Add(newWorkout);
            _context.SaveChanges();

            return CreatedAtRoute("GetWorkoutById", new { newWorkout.Id }, newWorkout);
        }
    }
}
