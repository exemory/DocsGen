using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class TeacherLoad : Entity
    {
        [Required]
        [Range(0, 1)]
        public byte Type { get; set; } // 1 - lection, 2 - practice

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
