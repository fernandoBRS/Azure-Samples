
using System;

namespace CloudDesignPatterns.CircuitBreakerPattern
{
    interface ICircuitBreakerStateStore
    {
        // Open, Half Open or Closed
        CircuitBreakerStateEnum State { get; }

        Exception LastException { get; }

        DateTime LastStateChangedDateUtc { get; }

        // Switches the state to Open and records the exception
        // that caused the change.
        void Trip(Exception ex);

        void Reset();

        void HalfOpen();

        bool IsClosed { get; }
    }
}
