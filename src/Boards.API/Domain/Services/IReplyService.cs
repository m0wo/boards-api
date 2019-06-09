using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IReplyService
    {
       Task<Reply> FindAsync(int replyId);
       Task<IEnumerable<Reply>> ListAsync(int postId);
       Task<ReplyResponse> SaveAsync(int postId, Reply reply, User user);
       Task<ReplyResponse> UpdateAsync(int replyId, Reply reply, User user);
       Task<ReplyResponse> DeleteAsync(int replyId, User user);
    }
}