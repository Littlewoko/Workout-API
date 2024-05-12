using Workout_API.DBContexts;
using Workout_API.Models;

namespace Workout_API.Utils
{
    public static class UserUtils
    {
        /// <param name="_context"></param>
        /// <param name="Email"></param>
        /// <param name="Id"></param>
        /// <returns>User instance or null</returns>
        public static User? HandleGetUser(DBContext _context, string Email, int Id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == Id && u.Email == Email);
        }

        /// <param name="_context"></param>
        /// <param name="Email"></param>
        /// <param name="Id"></param>
        /// <returns>User instance or null</returns>
        public static User? HandleGetUser(DBContext _context, string Email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == Email);
        }
    }
}
