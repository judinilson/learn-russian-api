using System.Security.Claims;
using System.Threading.Tasks;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    public class UserUtils
    {
        public static string GetUserEmail(ClaimsPrincipal user)
        {
            return user.FindFirst("preferred_username")?.Value;
        }

        public static string GetUserName(ClaimsPrincipal user)
        {
            return user.FindFirst("name")?.Value;
        }

        public static async Task<User> GetUser(AppDbContext context, ClaimsPrincipal user)
        {
            var founderUser = await context.Users.FirstOrDefaultAsync(u => u.Name == GetUserName(user));
            return founderUser;
        }
    }
}