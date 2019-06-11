using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boards.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Board> Boards { get; set; } = new List<Board>();
        public IList<Post> Posts {get; set;} = new List<Post>();
        public IList<Reply> Replies { get; set; } = new List<Reply>();
    }
}