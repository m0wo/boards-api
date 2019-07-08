using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boards.API.Persistence.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : ForumItem
    {
        protected readonly AppDbContext _context;

        public EfRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Remove(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }
    }
}