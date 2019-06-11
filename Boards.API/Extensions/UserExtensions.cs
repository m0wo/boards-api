using Boards.API.Domain.Models;

namespace Boards.API.Extensions
{
    public static class UserExtensions
    {
        public static bool IsItemEditable(this User user, ForumItem item)
        {
            if(user == null)
                return false;
            return user.Id == item.OwnerId;
        }
    }

}