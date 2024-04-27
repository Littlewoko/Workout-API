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
    /// 
    /// 
    /// </summary>
    public class Movement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Warmup sets will not be considered for PRS or represented in progress over time
        /// </summary>
        public Dictionary<int, Set> WarmupSets { get; set; }
        public Dictionary<int, Set> WorkingSets { get; set; }
        public HashSet<BodyPart> TargetedBodyparts { get; set; }
        public MovementPattern MovementPattern { get; set; }

        public Movement(int id, string name, string description, Dictionary<int, Set>? warmupSets, Dictionary<int, Set>? workingSets, HashSet<BodyPart>? bodyparts, MovementPattern movementPattern)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.MovementPattern = movementPattern;

            if(warmupSets != null)
            {
                this.WarmupSets = warmupSets;
            } else
            {
                this.WarmupSets = new Dictionary<int, Set>();
            }

            if (workingSets != null)
            {
                this.WorkingSets = workingSets;
            }
            else
            {
                this.WorkingSets = new Dictionary<int, Set>();
            }

            if(bodyparts != null)
            {
                this.TargetedBodyparts = bodyparts;
            } else
            {
                this.TargetedBodyparts = new HashSet<BodyPart>();
            }
        }

        public void AddWarmupSet(Set warmup)
        {
            this.WarmupSets.Add(warmup.Id, warmup);
        }

        public void AddWorkingSet(Set workingSet)
        {
            this.WorkingSets.Add(workingSet.Id, workingSet);
        }

        public void AddTargetedBodypart(BodyPart bodypart)
        {
            this.TargetedBodyparts.Add(bodypart);
        }

        public void RemoveWarmupSet(int id)
        {
            this.WarmupSets.Remove(id);
        }

        public void RemoveWorkingSet(int id)
        {
            this.WorkingSets.Remove(id);
        }

        public void RemoveTargetedBodyart(BodyPart bodypart)
        {
            this.TargetedBodyparts.Remove(bodypart);
        }




    }
}
