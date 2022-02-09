using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CredentialsDTO
    {
        [Required]
        public string Password { get; set; } = null!;
    }
}
