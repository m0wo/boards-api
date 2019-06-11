using Boards.API.Domain.Repositories;
using Boards.API.Persistence.Contexts;

namespace Boards.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}