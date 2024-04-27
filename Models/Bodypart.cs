namespace Workout_API.Models
{
    /// <summary>
    /// 
    /// Identify body part in use
    /// 
    /// </summary>
    public class Bodypart
    {
        private string _name; 

        /// <summary>
        /// Name of the body part in use
        /// 
        /// TODO: Should be populated via an enum
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">TODO: should be an enum</param>
        public Bodypart(string name)
        {
            this.Name = name;
        }
    }
}
