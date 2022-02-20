using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class TemplateException : Exception
    {
        public TemplateException()
        {
        }

        protected TemplateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TemplateException(string? message) : base(message)
        {
        }

        public TemplateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}