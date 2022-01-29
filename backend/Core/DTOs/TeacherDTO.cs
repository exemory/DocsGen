using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class TeacherDTO : DTO
    {
        public int Id { get; set; }

        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = null!;

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
