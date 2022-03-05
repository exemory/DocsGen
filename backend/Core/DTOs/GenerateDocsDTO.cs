using Core.DTOs.Base;

namespace Core.DTOs;

public class GenerateCurriculaDTO : DTO
{
    public int TemplateId { get; set; }
    public int[] TeacherIds { get; set; } = null!;
}