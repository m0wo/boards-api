using System;

namespace Boards.API.Domain.Models
{
    public class Reply 
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}