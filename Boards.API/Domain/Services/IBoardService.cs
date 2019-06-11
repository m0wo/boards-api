using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IBoardService
    {
       Task<Board> FindAsync(int id);
       Task<IEnumerable<Board>> ListAsync(); 
       Task<BoardResponse> SaveAsync(Board board, User user);
       Task<BoardResponse> UpdateAsync(int id, Board board, User user);
       Task<BoardResponse> DeleteAsync(int id, User user);
    }
}