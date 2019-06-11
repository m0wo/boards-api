using System.Threading.Tasks;

namespace Boards.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}