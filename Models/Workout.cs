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
        public Dictionary<int, Movement> Movements { get; set; }

        public Workout(DateTime date, Dictionary<int, Movement>? movements) 
        { 
            this.Date = date;
            if(movements != null)
            {
                this.Movements = movements;
            } else
            {
                this.Movements = new Dictionary<int, Movement>();
            }
        }

        public void AddMovement(Movement movement)
        {
            this.Movements.Add(movement.Id, movement);
        }

        public void RemoveMovement(Movement movement)
        {
            this.Movements.Remove(movement.Id);
        }
    }
}
