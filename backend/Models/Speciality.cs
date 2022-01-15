using System.ComponentModel.DataAnnotations;
using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class Speciality : Model
    {
        [Required]
        public string Code { get; set; } = default!;
        [Required]
        public string Name { get; set; } = default!;

        public int KnowledgeBranchId { get; set; }
        public KnowledgeBranch KnowledgeBranch { get; set; } = default!;

        public int HeadOfSMCId { get; set; }
        public HeadOfSMC HeadOfSMC { get; set; } = default!;

        public int GuarantorId { get; set; }
        public Guarantor Guarantor { get; set; } = default!;

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = default!;
    }
}
