using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IRepository<T> where T : ForumItem
    {
        Task<IEnumerable<T>> ListAsync();
        Task AddAsync(T t);
        Task<T> FindByIdAsync(int id);
        void Update(T t);
        void Remove(T t);
    }
}