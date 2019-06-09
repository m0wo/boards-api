using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IPostService
    {
       Task<Post> FindAsync(int postId);
       Task<IEnumerable<Post>> ListAsync(int boardId); 
       Task<PostResponse> SaveAsync(int boardId, Post post, User user);
       Task<PostResponse> UpdateAsync(int postId, Post post, User user);
       Task<PostResponse> DeleteAsync(int postId, User user);
    }
}