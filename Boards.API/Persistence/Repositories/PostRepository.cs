using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boards.API.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public async Task<Post> FindByIdAsync(int postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}