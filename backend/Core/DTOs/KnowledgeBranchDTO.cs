using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;

namespace Core.DTOs
{
    public class KnowledgeBranchDTO : DTO
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
    }
}
