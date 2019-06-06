using System;

namespace Boards.API.Resources
{
    public class PostResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public BoardResource Board { get; set; }
    }
}