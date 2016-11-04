using System;
using System.Configuration;
using Sandboxable.Microsoft.WindowsAzure.Storage;
using Sandboxable.Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageSample
{
    public class BlobStorage
    {
        public void UpdateBlob()
        {
            // Getting the storage account with the key-value defined in app.config file
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnStr"]);

            // Blob client will provide us access to containers and blobs
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Accessing a container
            var container = blobClient.GetContainerReference("files");
            container.CreateIfNotExists();

            // Defining container permissions
            container.SetPermissions(new BlobContainerPermissions
            {
                // listing and reading blobs with public access
                PublicAccess = BlobContainerPublicAccessType.Container,
            });

            UploadFile(container);
            ListAllBlobs(container);
            DownloadBlobFromStorage(container);
            DeleteBlob(container);
        }

        private static void UploadFile(CloudBlobContainer container)
        {
            // Name of the blob that will be created or updated
            var blockBlob = container.GetBlockBlobReference("myFile.txt");

            using (var fileStream = System.IO.File.OpenRead(@"C:\source\myFile.txt"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private static void ListAllBlobs(CloudBlobContainer container)
        {
            foreach (var item in container.ListBlobs())
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    var blob = (CloudBlockBlob)item;
                    Console.WriteLine($"Block blob: {blob.Uri}");
                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    var pageBlob = (CloudPageBlob)item;
                    Console.WriteLine($"Page blob: {pageBlob.Uri}");
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    var directory = (CloudBlobDirectory)item;
                    Console.WriteLine($"Directory: {directory.Uri}");
                }
            }
        }

        private static void DownloadBlobFromStorage(CloudBlobContainer container)
        {
            var blockBlob = container.GetBlockBlobReference("myFile.txt");

            using (var item = System.IO.File.OpenWrite(@"C:\source\myFile2.txt"))
            {
                blockBlob.DownloadToStream(item);
            }
        }

        private static void DeleteBlob(CloudBlobContainer container)
        {
            var blob = container.GetBlobReference("myFile.txt");
            blob.Delete();
        }
    }
}
