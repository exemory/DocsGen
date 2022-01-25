using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Base
{
    public abstract class PersonEntity : Entity
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        [Required]
        public string Patronymic { get; set; } = null!;
    }
}
