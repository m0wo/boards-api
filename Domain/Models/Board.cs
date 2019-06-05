using System;
using System.Collections.Generic;

namespace Boards.API.Domain.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}