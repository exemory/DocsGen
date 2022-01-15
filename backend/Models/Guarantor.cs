using DocsGen.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DocsGen.Models
{
    public class Guarantor : PersonModel
    {
        public string? AcademicDegree { get; set; }

        [Required]
        public string AcademicRank { get; set; } = default!;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Speciality? Speciality { get; set; }
    }
}
