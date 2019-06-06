using Boards.API.Domain.Models;

namespace Boards.API.Extensions
{
    public static class UserExtensions
    {
        public static bool IsBoardEditable(this User user, Board board)
        {
            if(user == null)
                return false;
            return user.Id == board.OwnerId;
        }
    }

}