using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Boards.API.Domain.Security.Hashing;
using Boards.API.Persistence;
using Boards.API.Persistence.Contexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Boards.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            using(var context =  scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
                var passwordHasher = scope.ServiceProvider.GetService<IPasswordHasher>(); 
                DbSeed.Seed(context, passwordHasher);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
