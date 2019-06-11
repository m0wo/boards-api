
using Microsoft.EntityFrameworkCore;
using Boards.API.Domain.Models;
using System;

namespace Boards.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=forum.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Board>().ToTable("Boards");
            
            builder.Entity<Board>().HasKey(p => p.Id);
            builder.Entity<Board>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<Board>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Board>().Property(p => p.Description).HasMaxLength(500);

            builder.Entity<Board>().HasMany(b => b.Posts).WithOne(p => p.Board);
            builder.Entity<Board>().HasOne(b => b.Owner).WithMany(o => o.Boards);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(300);
            builder.Entity<Post>().Property(p => p.Body).HasMaxLength(2000);

            builder.Entity<Post>().HasMany(p => p.Replies).WithOne(p => p.Post);
            builder.Entity<Post>().HasOne(p => p.Owner).WithMany(o => o.Posts);


            builder.Entity<Reply>().ToTable("Replies");
            builder.Entity<Reply>().HasKey(r => r.Id);
            builder.Entity<Reply>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<Reply>().Property(p => p.Body).IsRequired().HasMaxLength(2000);

            builder.Entity<Reply>().HasOne(r => r.Post).WithMany(p => p.Replies);
            builder.Entity<Reply>().HasOne(r => r.Owner).WithMany(o => o.Replies);
        }
    }
}