namespace Boards.API.Domain.Models
{
    public class ForumItem
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}