using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> ListAsync(); 
        Task AddAsync(Board board);
        Task<Board> FindByIdAsync(int id);
        void Update(Board board);
        void Remove(Board board);
    }
}