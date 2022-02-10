using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : EntityException
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message)
            : base(message)
        {
        }

        public EntityNotFoundException(Type? entityType)
            : base(entityType)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(string? message, Type? entityType)
            : base(message, entityType)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException, Type? entityType)
            : base(message, innerException, entityType)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
