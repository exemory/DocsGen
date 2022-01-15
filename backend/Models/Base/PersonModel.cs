using System.ComponentModel.DataAnnotations;

namespace DocsGen.Models.Base
{
    public abstract class PersonModel : Model
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Surname { get; set; } = default!;
        [Required]
        public string Patronymic { get; set; } = default!;

        public virtual string FullName
        {
            get => $"{Surname} {Name} {Patronymic}";
        }

        public virtual string Surname_NBSP_ShortName_Dot_NBSP_ShortPatr_Dot
        {
            get => $"{Surname}\u00A0{Name[0]}.\u00A0{Patronymic[0]}.";
        }

        public virtual string Surname_UND_ShortName_Dot_UND_ShortPatr_Dot
        {
            get => $"{Surname}_{Name[0]}._{Patronymic[0]}.";
        }
    }
}
