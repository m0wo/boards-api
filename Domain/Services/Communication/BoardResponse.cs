
using Boards.API.Domain.Models;

namespace Boards.API.Domain.Services.Communication
{
    public class BoardResponse : BaseResponse
    {
        public Board Board { get; private set;}

        public BoardResponse(bool success, string message, Board board) : base(success, message)
        {
            Board = board;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="board">Saved board.</param>
        /// <returns>Response.</returns>
        public BoardResponse(Board board) : this(true, string.Empty, board)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BoardResponse(string message) : this(false, message, null)
        { }
    }
}