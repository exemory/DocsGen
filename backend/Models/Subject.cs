using System.ComponentModel.DataAnnotations;
using DocsGen.Models.Base;

namespace DocsGen.Models
{
    public class Subject : Model
    {
        [Required]
        public string Name { get; set; } = default!;

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = default!;

        public string NameWithUnderscores
        {
            get => Name.Replace(' ', '_');
        }
    }
}
