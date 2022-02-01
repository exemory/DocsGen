using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class SpecialtyDTO : DTO
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;

        public int KnowledgeBranchId { get; set; }

        public int HeadOfSmcId { get; set; }

        public int GuarantorId { get; set; }
    }
}
