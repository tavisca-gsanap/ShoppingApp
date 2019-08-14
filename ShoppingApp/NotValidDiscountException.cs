using System;
using System.Runtime.Serialization;

namespace ShoppingApp
{
    [Serializable]
    public class NotValidDiscountException : Exception
    {
        public NotValidDiscountException()
        {
        }

        public NotValidDiscountException(string message) : base(message)
        {
        }

        public NotValidDiscountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotValidDiscountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}