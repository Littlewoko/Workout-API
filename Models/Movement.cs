using Workout_API.Enums;

namespace Workout_API.Models
{
    /// <summary>
    /// 
    /// A given movement consisting of sets. A movement will target given bodyparts
    /// and will follow a given movement pattern
    /// 
    /// Example: Bench Press will target the chest and follows the push movement pattern
    /// 
    /// Warmup sets will not be considered for PRS or represented in progress over time
    /// 
    /// </summary>
    public class Movement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Set> WarmupSets { get; set; }
        public List<Set> WorkingSets { get; set; }
        public List<Bodypart> TargetedBodyparts { get; set; }
        public MovementPattern MovementPattern { get; set; }

        public Movement(string name, string description, List<Set>? warmupSets, List<Set>? workingSets, List<Bodypart>? bodyparts, MovementPattern movementPattern)
        {
            this.Name = name;
            this.Description = description;
            this.MovementPattern = movementPattern;

            if(warmupSets != null)
            {
                this.WarmupSets = warmupSets;
            } else
            {
                this.WarmupSets = new List<Set>();
            }

            if (workingSets != null)
            {
                this.WorkingSets = workingSets;
            }
            else
            {
                this.WorkingSets = new List<Set>();
            }

            if(bodyparts != null)
            {
                this.TargetedBodyparts = bodyparts;
            } else
            {
                this.TargetedBodyparts = new List<Bodypart>();
            }
        }
    }
}
