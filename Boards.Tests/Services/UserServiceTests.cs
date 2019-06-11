using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Repositories;
using Boards.API.Domain.Security.Hashing;
using Boards.API.Domain.Services;
using Boards.API.Services;
using Moq;
using Xunit;

namespace Boards.Tests.Services
{
    public class UserServiceTests
    {
        private Mock<IPasswordHasher> _passwordHasher;
        private Mock<IUserRepository> _userRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private IUserService _userService;

        public UserServiceTests()
        {
            SetupMocks();
            _userService = new UserService(_userRepository.Object, _unitOfWork.Object, _passwordHasher.Object);
        }

        private void SetupMocks()
        {
            _passwordHasher = new Mock<IPasswordHasher>();
            _passwordHasher.Setup(ph => ph.HashPassword(It.IsAny<string>())).Returns("123");

            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(r => r.FindByEmailAsync("test@example.org"))
                .ReturnsAsync(new User { Id = 1, Email = "test@example.org" });

            _userRepository.Setup(r => r.FindByEmailAsync("secondtest@example.org"))
                .Returns(Task.FromResult<User>(null));

            _userRepository.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);
        }

        [Fact]
        public async Task Should_Create_Non_Existing_User()
        {
            var user = new User { Email = "testuser@example.org", Password = "123" };
            
            var response = await _userService.CreateUserAsync(user);

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(user.Email, response.User.Email);
            Assert.Equal(user.Password, response.User.Password);
        }

        [Fact]
        public async Task Should_Not_Create_Existing_User()
        {
            var user = new User { Email = "test@example.org", Password = "123" };
        
            var response = await _userService.CreateUserAsync(user);

            Assert.False(response.Success);
            Assert.Equal("Email already in use.", response.Message);
        }

        [Fact]
        public async Task Should_Find_Existing_User_By_Email()
        {
            var user = await _userService.FindByEmailAsync("test@example.org");
            Assert.NotNull(user);
            Assert.Equal("test@example.org", user.Email);
        }

        [Fact]
        public async Task Should_Return_Null_On_Non_Existing_User()
        {
            var user = await _userService.FindByEmailAsync("null@example.org");
            Assert.Null(user);
        }
    }
}