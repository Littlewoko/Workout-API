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
        /// 
        /// 
        /// </summary>
        /// <param name="reps">number completed</param>
        /// <param name="weight">in kg</param>
        /// <param name="distance">in meters</param>
        /// <param name="time">in ms</param>
        public Set(int? reps, int? weight, float? distance, int? time) 
        { 
            this.Reps = reps;
            this.Weight = weight;
            this.Distance = distance;
            this.Time = time;
        }
    }
}
