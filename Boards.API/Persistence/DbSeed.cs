using System.Collections.Generic;
using System.Linq;
using Boards.API.Domain.Models;
using Boards.API.Domain.Security.Hashing;
using Boards.API.Persistence.Contexts;

namespace Boards.API.Persistence
{
    public class DbSeed
    {
        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            if (context.Users.Count() == 0)
            {
                var users = new List<User>
                {
                    new User { Email = "test@example.org", Password = passwordHasher.HashPassword("password") },
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}