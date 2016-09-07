
using System;

namespace CloudDesignPatterns.CircuitBreakerPattern
{
    public class CircuitBreakerMain
    {
        public void StartCircuitBreaker()
        {
            // 60 seconds
            var openToHalfOpenWaitTime = new TimeSpan(0, 0, 0, 60, 0);

            var breaker = new CircuitBreaker(openToHalfOpenWaitTime);

            try
            {
                breaker.ExecuteAction(() =>
                {
                    // Your code here.
                });
            }
            catch (CircuitBreakerOpenException ex)
            {
                // Perform some different action when the breaker is open.
                // Last exception details are in the inner exception.
            }
            catch (Exception ex)
            {
                // Other exceptions
            }
        }
    }
}
