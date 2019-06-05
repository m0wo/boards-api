using System.Collections.Generic;
using System.Threading.Tasks;
using Boards.API.Domain.Models;
using Boards.API.Domain.Services.Communication;

namespace Boards.API.Domain.Services
{
    public interface IPostService
    {
       Task<Post> FindAsync(int id);
       Task<IEnumerable<Post>> ListAsync(); 
       Task<PostResponse> SaveAsync(Post post);
       Task<PostResponse> UpdateAsync(int id, Post post);
       Task<PostResponse> DeleteAsync(int id);
    }
}