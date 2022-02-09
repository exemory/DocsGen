using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        private readonly Type? _entityType;

        public virtual Type? EntityType => _entityType;

        public override string Message
        {
            get
            {
                string msg = base.Message;

                if (_entityType != null)
                {
                    return $"{msg} (Entity '{_entityType.Name}')";
                }

                return msg;
            }
        }

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message)
            : base(message)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(string? message, Type? entityType)
            : base(message)
        {
            _entityType = entityType;
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
