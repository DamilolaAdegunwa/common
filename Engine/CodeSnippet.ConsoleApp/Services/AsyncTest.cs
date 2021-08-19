using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace CodeSnippet.ConsoleApp
{
    public class AsyncTest
    {
        public static async Task<User> GetUserAsync(int userId)
        {
            // Code omitted:
            //
            // Given a user Id {userId}, retrieves a User object corresponding
            // to the entry in the database with {userId} as its Id.
            return default;
        }
        /// <summary>
        /// Get a set of user data asynchronously
        /// </summary>
        /// <remarks>
        /// Task.WhenAll was leveraged to make this faster, asking for each user asynchronously, when collecting all into one...
        /// </remarks>
        /// <param name="userIds"></param>
        /// <returns>Task<User[]></returns>
        public static Task<User[]> GetUsersAsync(IEnumerable<int> userIds)
        {
            //like this 
            var getUserTasks_ = new List<Task<User>>();
            foreach (int userId in userIds)
            {
                getUserTasks_.Add(GetUserAsync(userId));
            }
            //var @return = await Task.WhenAll(getUserTasks_);
            //or this
            var getUserTasks = userIds.Select(id => GetUserAsync(id));
            //var resp = await Task.WhenAll(getUserTasks);
            return Task.WhenAll(getUserTasks);
            //return resp;
        }

        public class User
        {
        }
    }
}
