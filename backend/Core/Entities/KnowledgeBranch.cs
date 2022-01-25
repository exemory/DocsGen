using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class KnowledgeBranch : Entity
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
    }
}
