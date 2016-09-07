using System;
using System.Runtime.Serialization;

namespace CloudDesignPatterns.CircuitBreakerPattern
{
    [Serializable]
    internal class CircuitBreakerOpenException : Exception
    {
        private Exception lastException;

        public CircuitBreakerOpenException()
        {
        }

        public CircuitBreakerOpenException(string message) : base(message)
        {
        }

        public CircuitBreakerOpenException(Exception lastException)
        {
            this.lastException = lastException;
        }

        public CircuitBreakerOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CircuitBreakerOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}