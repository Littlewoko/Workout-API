namespace Workout_API.Models
{
    /// <summary>
    /// 
    /// A single completed set, a set is a single instance of completing
    /// some movement. 
    /// 
    /// Example: A group of reps done on after another
    /// Example: A single instance of distance moved during a run or walk
    /// Example: The time to complete a given movement such as a Plank
    /// 
    /// </summary>
    public class Set
    {
        public int Id { get; set; }
        public int? Reps { get; set; }

        /// <summary>
        /// 
        /// Measured in Kilograms
        /// 
        /// </summary>
        public int? Weight { get; set; } 

        /// <summary>
        /// 
        /// Measured in Meters
        /// 
        /// </summary>
        public float? Distance { get; set; }

        /// <summary>
        /// 
        /// Measured in Miliseconds
        /// 
        /// </summary>
        public int? Time { get; set; } 

        /// <summary>
        /// 
        /// Describes the relative order of this set within its grouping
        /// 
        /// </summary>
        public int OrderStep { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="reps">number completed</param>
        /// <param name="weight">in kg</param>
        /// <param name="distance">in meters</param>
        /// <param name="time">in ms</param>
        public Set(int id, int? reps, int? weight, float? distance, int? time, int orderStep = 0) 
        { 
            this.Id = id;
            this.Reps = reps;
            this.Weight = weight;
            this.Distance = distance;
            this.Time = time;
            this.OrderStep = orderStep; 
        }
    }
}
