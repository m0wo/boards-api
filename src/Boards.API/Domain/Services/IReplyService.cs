using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IReplyService
    {
       Task<Reply> FindAsync(int id);
       Task<IEnumerable<Reply>> ListAsync();
       Task<ReplyResponse> SaveAsync(Reply reply, User user);
       Task<ReplyResponse> UpdateAsync(int id, Reply reply, User user);
       Task<ReplyResponse> DeleteAsync(int id, User user);
    }
}