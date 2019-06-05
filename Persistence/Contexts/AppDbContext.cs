
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Boards.API.Domain.Models;

namespace Boards.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Board>().ToTable("Boards");
            builder.Entity<Board>().HasKey(p => p.Id);
            builder.Entity<Board>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            //TODO: I assume this is smart enough to use the current epoch ? we'll find out when testing.
            builder.Entity<Board>().Property(p => p.CreatedAt).IsRequired().ValueGeneratedOnAdd().ValueGeneratedOnAdd();
            builder.Entity<Board>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Board>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Board>().HasMany(p => p.Posts).WithOne(p => p.Board).HasForeignKey(p => p.BoardId);

            builder.Entity<Board>().HasData
            (
                new Board { Id = 100, Name = "Staff", Description = "This is a board for internal discussion." }, // Id set manually due to in-memory provider
                new Board { Id = 101, Name = "Suggestions", Description = "For user suggestions."},
                new Board { Id = 102, Name = "Funny" }
            );

        }
    }
}