using System;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CloudDesignPatterns.RetryPattern
{
    public class Retry
    {
        private const int retryCount = 3;

        public async Task RetryAsync()
        {
            var currentRetry = 0;

            for (;;)
            {
                try
                {
                    // Calling external service.
                    await TransientOperationAsync();

                    // Return or break.
                    break;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Operation Exception");

                    currentRetry++;

                    // Check if the exception thrown was a transient exception
                    // based on the logic in the error detection strategy.
                    // Determine whether to retry the operation, as well as how 
                    // long to wait, based on the retry strategy.
                    if (currentRetry > retryCount || !IsTransient(ex))
                    {
                        // If this is not a transient error 
                        // or we should not retry re-throw the exception. 
                        throw;
                    }
                }

                // Wait to retry the operation.
                // Consider calculating an exponential delay here and 
                // using a strategy best suited for the operation and fault.
                await Task.Delay(1000);
            }
        }

        // Async method that wraps a call to a remote service (details not shown).
        private async Task TransientOperationAsync()
        {
            // Your logic here.
        }

        private static bool IsTransient(Exception ex)
        {
            // Determine if the exception is transient.
            // In some cases this may be as simple as checking the exception type, in other 
            // cases it may be necessary to inspect other properties of the exception.
            if (ex is OdbcException)
                return true;

            var webException = ex as WebException;

            if (webException != null)
            {
                // If the web exception contains one of the following status values 
                // it may be transient.
                return new[] {
                    WebExceptionStatus.ConnectionClosed,
                    WebExceptionStatus.Timeout,
                    WebExceptionStatus.RequestCanceled
                }.Contains(webException.Status);
            }

            // Additional exception checking logic goes here.
            return false;
        }
    }
}
