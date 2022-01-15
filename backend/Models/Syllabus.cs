using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class Syllabus : Model
    {
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

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = default!;
    }
}
