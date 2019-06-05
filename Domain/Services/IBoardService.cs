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
       Task<BoardResponse> SaveAsync(Board board);
       Task<BoardResponse> UpdateAsync(int id, Board board);
       Task<BoardResponse> DeleteAsync(int id);
    }
}