using System;
using System.Runtime.Serialization;

namespace ShoppingApp
{
    [Serializable]
    public class NotValidQuantityException : Exception
    {
        public NotValidQuantityException()
        {
        }

        public NotValidQuantityException(string message) : base(message)
        {
        }

        public NotValidQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotValidQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}