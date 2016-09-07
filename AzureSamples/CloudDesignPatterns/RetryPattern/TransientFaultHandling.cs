using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace CloudDesignPatterns.RetryPattern
{
    public class TransientFaultHandling
    {
        // Transient Fault Handling for Azure Storage
        private void HandleTransientFault()
        {
            const string accountName = "accountName";
            const string accountKey = "accountKey";
            const string blobContainerName = "images";
            const int retryCount = 10;

            var storageCredentials = new StorageCredentials(accountName, accountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();

            blobClient.DefaultRequestOptions.RetryPolicy =
                new ExponentialRetry(TimeSpan.FromSeconds(2), retryCount);

            var blobContainer = blobClient.GetContainerReference(blobContainerName);

            if (blobContainer.Exists())
            {
                // your logic here.
            }
        }
    }
}
