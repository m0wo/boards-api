using System.ComponentModel.DataAnnotations;

namespace Boards.API.Resources
{
    public class SavePostResource
    {
       [Required] 
       [MaxLength(300)]
       public string Title { get; set; }

       [Required]
       [MaxLength(2000)]
       public string Body { get; set; }

       [Required]
       public int BoardId { get; set; }
    }
}