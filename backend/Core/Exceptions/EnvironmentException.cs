using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class EnvironmentException : Exception
    {
        public EnvironmentException()
            : base()
        {
        }

        public EnvironmentException(string message)
            : base(message)
        {
        }

        public EnvironmentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EnvironmentException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }
    }
}
