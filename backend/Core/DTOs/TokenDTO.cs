using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class TokenDTO
    {
        [Required]
        public string Token { get; set; } = null!;
    }
}
