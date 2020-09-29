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
        public static async Task<User[]> GetUsersAsync(IEnumerable<int> userIds)
        {
            //like this 
            var getUserTasks_ = new List<Task<User>>();
            foreach (int userId in userIds)
            {
                getUserTasks_.Add(GetUserAsync(userId));
            }
            var @return = await Task.WhenAll(getUserTasks_);
            //or this
            var getUserTasks = userIds.Select(id => GetUserAsync(id));
            var resp = await Task.WhenAll(getUserTasks);
            return resp;
        }

        public class User
        {
        }
    }
}
