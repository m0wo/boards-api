using System.ComponentModel.DataAnnotations;

namespace Boards.API.Resources
{
    public class SaveReplyResource
    {
        [Required]
        [MaxLength(2000)]
        public string Body { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}