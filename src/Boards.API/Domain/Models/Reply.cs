using System;

namespace Boards.API.Domain.Models
{
    public class Reply : ForumItem
    {
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}