using System.ComponentModel.DataAnnotations;
using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class TeacherLoad : Model
    {
        [Required]
        [Range(0, 1)]
        public byte Type { get; set; } // 1 - lection, 2 - practice

        [Required]
        [Range(1, 6)]
        public byte Year { get; set; } // 1 - 6

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = default!;

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; } = default!;

        public int SyllabusId { get; set; }
        public Syllabus Syllabus { get; set; } = default!;
    }
}
