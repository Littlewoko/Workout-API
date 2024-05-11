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
            if (!_context.Workouts.Any())
            {
                return NoContent();
            }

            List<Workout> workouts = _context.Workouts.ToList();

            return Ok(workouts);
        }

        [HttpGet("getById/{id}", Name = "GetWorkoutById")]
        public IActionResult GetById(int Id)
        {
            Workout? workout = HandleGetWorkout(Id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost(Name = "CreateWorkout")]
        public IActionResult CreateWorkout([FromBody] Workout newWorkout)
        {
            try
            {
                User? user = HandleGetUser(newWorkout.User.Email, newWorkout.User.Id);
                if (user == null)
                {
                    return BadRequest("Provided user does not exist");
                }

                newWorkout.User = user; // ensure FK constraints are properly put in place
                HandleCreateWorkout(newWorkout);
            }
            catch (Exception _)
            {
                return StatusCode(500);
            }

            return CreatedAtRoute("GetWorkoutById", new { newWorkout.Id }, newWorkout);
        }

        private Workout? HandleGetWorkout(int Id)
        {
            return _context.Workouts.SingleOrDefault(u => u.Id == Id);
        }

        /// <param name="Email"></param>
        /// <returns>User instance or null</returns>
        private User? HandleGetUser(string Email, int Id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == Id || u.Email == Email);
        }

        private void HandleCreateWorkout(Workout newWorkout)
        {
            _context.Workouts.Add(newWorkout);
            _context.SaveChanges();
        }
    }
}
