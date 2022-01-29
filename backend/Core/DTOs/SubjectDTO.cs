using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class SubjectDTO : DTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
