using System;
using System.Runtime.Serialization;

namespace _10366827
{
    [Serializable]
    internal class InvalidBetException : Exception
    {
        public InvalidBetException()
        {
        }

        public InvalidBetException(string message) : base(message)
        {
        }

        public InvalidBetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}