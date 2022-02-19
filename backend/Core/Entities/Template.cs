using Core.Entities.Base;

namespace Core.Entities
{
    public  class Template : Entity
    {
        public DateOnly UploadDate { get; set; }
        
        public byte[] Content { get; set; } = null!;
    }
}
