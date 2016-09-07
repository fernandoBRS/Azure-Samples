using System;

namespace CloudDesignPatterns.CircuitBreakerPattern
{
    internal class CircuitBreakerStateStoreFactory : ICircuitBreakerStateStore
    {
        public CircuitBreakerStateEnum State { get; set; }
        public Exception LastException { get; set; }
        public DateTime LastStateChangedDateUtc { get; set; }

        public void Trip(Exception ex)
        {
            State = CircuitBreakerStateEnum.Open;
            LastException = ex;
            LastStateChangedDateUtc = DateTime.UtcNow;
            IsClosed = false;
        }

        public void Reset()
        {
            State = CircuitBreakerStateEnum.Closed;
            IsClosed = true;
        }

        public void HalfOpen()
        {
            State = CircuitBreakerStateEnum.HalfOpen;
            IsClosed = false;
        }

        public bool IsClosed { get; set; }
    }
}