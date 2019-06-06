using Boards.API.Domain.Models;

namespace Boards.API.Domain.Services.Communication
{
    public class PostResponse : BaseResponse
    {
        public Post Post { get; private set; }

        public PostResponse(bool success, string message, Post post) : base(success, message)
        {
           Post = post; 
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="post">Saved post.</param>
        /// <returns>Response.</returns>
        public PostResponse(Post post) : this(true, string.Empty, post)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PostResponse(string message) : this(false, message, null)
        { }
    }
}