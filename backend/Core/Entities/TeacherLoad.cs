using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;
using Core.Enums;

namespace Core.Entities
{
    public class TeacherLoad : Entity
    {
        [Required]
        public TeacherLoadType Type { get; set; }

        [Required]
        [Range(1, 6)]
        public byte Year { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; } = null!;

        public int SyllabusId { get; set; }
        public Syllabus Syllabus { get; set; } = null!;
    }
}
