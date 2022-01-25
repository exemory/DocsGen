using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Subject : Entity
    {
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<TeacherLoad> TeacherLoads { get; set; } = new List<TeacherLoad>();
    }
}
