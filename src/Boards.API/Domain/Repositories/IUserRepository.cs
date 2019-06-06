using System.Threading.Tasks;
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindByEmailAsync(string email);
    }
}