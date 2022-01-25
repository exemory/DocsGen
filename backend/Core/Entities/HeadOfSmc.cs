using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HeadOfSmc : PersonEntity
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = null!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
    }
}
