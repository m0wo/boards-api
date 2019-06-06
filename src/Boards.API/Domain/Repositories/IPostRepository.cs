using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> ListAsync(); 
        Task AddAsync(Post post);
        Task<Post> FindByIdAsync(int id);
        void Update(Post post);
        void Remove(Post post);
    }
}