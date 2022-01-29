using Core.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class HeadOfSmcDTO : DTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        [Required]
        public string Patronymic { get; set; } = null!;

        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = null!;

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
