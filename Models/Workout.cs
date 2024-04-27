namespace Workout_API.Models
{
    /// <summary>
    /// 
    /// A workout is a single session consisting of one or more movements
    /// 
    /// </summary>
    public class Workout
    {
        public DateTime Date { get; set; }
        public List<Movement> Movements { get; set; }

        public Workout(DateTime date, List<Movement>? movements) 
        { 
            this.Date = date;
            if(movements != null)
            {
                this.Movements = movements;
            } else
            {
                this.Movements = new List<Movement>();
            }
        }
    }
}
