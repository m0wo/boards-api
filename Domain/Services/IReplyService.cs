using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IReplyService
    {
       Task<IEnumerable<Reply>> ListAsync();
       Task<ReplyResponse> SaveAsync(Reply reply);
       Task<ReplyResponse> UpdateAsync(int id, Reply reply);
       Task<ReplyResponse> DeleteAsync(int id);

    }
}