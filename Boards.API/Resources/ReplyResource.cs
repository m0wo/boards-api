using System;

namespace Boards.API.Resources
{
    public class ReplyResource
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}