using System.ComponentModel.DataAnnotations;

namespace Workout_API.Models
{
    /// <summary>
    /// 
    /// A workout is a single session consisting of one or more movements
    /// 
    /// </summary>
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Movement> Movements { get; set; }
    
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
