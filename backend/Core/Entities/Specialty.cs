using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Specialty : Entity
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;

        public int KnowledgeBranchId { get; set; }
        public KnowledgeBranch KnowledgeBranch { get; set; } = null!;

        public int HeadOfSMCId { get; set; }
        public HeadOfSmc HeadOfSMC { get; set; } = null!;

        public int GuarantorId { get; set; }
        public Guarantor Guarantor { get; set; } = null!;

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = new List<TeacherLoad>();
    }
}
