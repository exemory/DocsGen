using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class EntityException : Exception
    {
        protected readonly string? _entityTypeName;

        public virtual string? EntityTypeName => _entityTypeName;

        public override string Message
        {
            get
            {
                string msg = base.Message;

                if (_entityTypeName != null)
                {
                    return $"{msg} (Entity '{_entityTypeName}')";
                }

                return msg;
            }
        }

        public EntityException()
        {
        }

        public EntityException(string? message)
            : base(message)
        {
        }

        public EntityException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public EntityException(Type? entityType)
            : this(null, entityType)
        {
        }

        public EntityException(string? message, Type? entityType)
            : this(message, null, entityType)
        {
        }

        public EntityException(string? message, Exception? innerException, Type? entityType)
            : this(message, innerException)
        {
            _entityTypeName = entityType?.Name;
        }

        protected EntityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
