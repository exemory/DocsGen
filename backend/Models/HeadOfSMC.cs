using DocsGen.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DocsGen.Models
{
    public class HeadOfSMC : PersonModel
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = default!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<Speciality> Specialties { get; set; } = default!;
    }
}
