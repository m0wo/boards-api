using System;
using System.Collections.Generic;

namespace Boards.API.Domain.Models
{
    public class Post : ForumItem
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Reply> Replies { get; set; } = new List<Reply>();

        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}