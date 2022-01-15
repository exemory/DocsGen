using System.ComponentModel.DataAnnotations;
using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class Teacher : PersonModel
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = default!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = default!;
    }
}
