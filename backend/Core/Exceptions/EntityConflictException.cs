using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class EntityConflictException : EntityException
    {
        public EntityConflictException()
        {
        }

        public EntityConflictException(string? message) : base(message)
        {
        }

        public EntityConflictException(Type? entityType) : base(entityType)
        {
        }

        public EntityConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public EntityConflictException(string? message, Type? entityType) : base(message, entityType)
        {
        }

        public EntityConflictException(string? message, Exception? innerException, Type? entityType) : base(message, innerException, entityType)
        {
        }

        protected EntityConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
