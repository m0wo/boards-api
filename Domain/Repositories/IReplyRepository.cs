using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IReply
    {
        Task<IEnumerable<Reply>> ListAsync();
        Task AddSync(Reply reply);
        Task<Reply> FindByIdAsync(int id);
        void Update(Reply reply);
        void Remove(Reply reply);
    }
}