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
            using (_context)
            {
                if(!_context.Workouts.Any())
                {
                    return NoContent();
                }

                workouts = _context.Workouts.ToList();
            }

            return Ok(workouts);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int Id)
        {
            Workout? workout = null;
            using (_context)
            {
                workout = _context.Workouts.SingleOrDefault(u => u.Id == Id);
            }

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost(Name = "CreateWorkout")]
        public IActionResult CreateWorkout([FromBody] Workout newWorkout)
        {
            using(_context)
            {
                _context.Workouts.Add(newWorkout);
                _context.SaveChanges();
            }

            return CreatedAtRoute("GetWorkout", new { newWorkout.Id }, newWorkout);
        }
    }
}
