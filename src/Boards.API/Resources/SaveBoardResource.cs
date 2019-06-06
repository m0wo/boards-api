using System.ComponentModel.DataAnnotations;

namespace Boards.API.Resources
{
    public class SaveBoardResource
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}