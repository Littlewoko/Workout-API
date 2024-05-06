using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workout_API.Models
{
    [PrimaryKey(nameof(Id), nameof(Email))]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
    }
}
