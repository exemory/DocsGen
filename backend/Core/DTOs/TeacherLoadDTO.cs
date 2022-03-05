using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;
using Core.Enums;

namespace Core.DTOs
{
    public class TeacherLoadDTO : DTO
    {
        public int Id { get; set; }

        [Required]
        public TeacherLoadType Type { get; set; }

        [Required]
        [Range(1, 6)]
        public byte Year { get; set; }

        public int TeacherId { get; set; }

        public int SubjectId { get; set; }

        public int SpecialtyId { get; set; }

        public int SyllabusId { get; set; }
    }
}
