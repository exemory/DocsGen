using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Teacher : PersonEntity
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = null!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = new List<TeacherLoad>();
    }
}
