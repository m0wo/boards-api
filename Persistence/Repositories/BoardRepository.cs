
using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boards.API.Persistence.Repositories
{
    public class BoardRepository : BaseRepository, IBoardRepository
    {
        public BoardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }

        public async Task<Board> FindByIdAsync(int id)
        {
            return await _context.Boards.FindAsync(id);
        }

        public async Task<IEnumerable<Board>> ListAsync()
        {
            return await _context.Boards.ToListAsync();
        }

        public void Remove(Board board)
        {
            _context.Boards.Remove(board);
        }

        public void Update(Board board)
        {
            _context.Boards.Update(board);
        }
    }
}