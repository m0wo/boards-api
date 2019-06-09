using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boards.API.Persistence.Repositories
{
    public class ReplyRepository : BaseRepository, IReplyRepository
    {
        public ReplyRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task AddAsync(Reply reply)
        {
            await _context.Replies.AddAsync(reply);
        }

        public async Task<Reply> FindByIdAsync(int replyId)
        {
            return await _context.Replies.FindAsync(replyId);
        }

        public async Task<IEnumerable<Reply>> ListAsync()
        {
            return await _context.Replies.Include(r => r.Post).ToListAsync();
        }

        public void Remove(Reply reply)
        {
            _context.Replies.Remove(reply);
        }

        public void Update(Reply reply)
        {
            _context.Replies.Update(reply);
        }
    }
}