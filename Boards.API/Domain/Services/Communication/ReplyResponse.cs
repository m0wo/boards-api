using Boards.API.Domain.Models;

namespace Boards.API.Domain.Services.Communication
{
    public class ReplyResponse : BaseResponse
    {
        public Reply Reply { get; private set; } 
        public ReplyResponse(bool success, string message, Reply reply) : base(success, message)
        {
            Reply = reply;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="reply">Saved reply.</param>
        /// <returns>Response.</returns>
        public ReplyResponse(Reply reply) : this(true, string.Empty, reply)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ReplyResponse(string message) : this(false, message, null)
        { }

    }
}