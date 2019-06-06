using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Security.Hashing;
using Boards.API.Domain.Services;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateUserAsync(User user)
        {
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            if(existingUser != null)
            {
                return new UserResponse("Email already in use.");
            } 

            user.Password = _passwordHasher.HashPassword(user.Password);

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }
    }
}