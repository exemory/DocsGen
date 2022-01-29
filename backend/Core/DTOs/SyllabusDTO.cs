using Core.DTOs.Base;

namespace Core.DTOs
{
    public class SyllabusDTO : DTO
    {
        public int Id { get; set; }

        public string? Credits { get; set; }
        public ushort? TotalHours { get; set; }
        public ushort? ClassroomHours { get; set; }
        public ushort? LectureHours { get; set; }
        public ushort? LabHours { get; set; }
        public ushort? PracticalHours { get; set; }

        public byte? CourseProjects { get; set; }
        public byte? CourseWork { get; set; }
        public byte? RGR { get; set; }
        public byte? R { get; set; }

        public string? FormOfControl { get; set; }

        public byte? Semester { get; set; }
    }
}
