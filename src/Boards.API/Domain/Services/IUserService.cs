using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(User user);
        Task<User> FindByEmailAsync(string email);
    }
}