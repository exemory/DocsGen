using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Guarantor : PersonEntity
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = null!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Specialty? Specialty { get; set; }
    }
}
