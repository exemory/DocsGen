using System.ComponentModel.DataAnnotations;
using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class KnowledgeBranch : Model
    {
        [Required]
        public string Code { get; set; } = default!;
        [Required]
        public string Name { get; set; } = default!;

        public ICollection<Speciality> Specialities { get; set; } = default!;
    }
}
