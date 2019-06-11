using System.ComponentModel.DataAnnotations;

namespace Boards.API.Resources
{
    public class RevokeTokenResource
    {
       [Required]
        public string Token { get; set; }
    }
}