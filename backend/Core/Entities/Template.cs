using Core.Entities.Base;

namespace Core.Entities
{
    public  class Template : Entity
    {
        public DateTime UploadDate { get; set; }
        
        public byte[] Content { get; set; } = null!;
    }
}
