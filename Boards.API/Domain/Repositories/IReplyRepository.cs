using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IReplyRepository
    {
        Task<IEnumerable<Reply>> ListAsync();
        Task AddAsync(Reply reply);
        Task<Reply> FindByIdAsync(int replyId);
        void Update(Reply reply);
        void Remove(Reply reply);
    }
}