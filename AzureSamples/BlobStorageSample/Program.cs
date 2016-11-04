using System;

namespace AzureStorageSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var blobStorage = new BlobStorage();
            var tableStorage = new TableStorage();

            blobStorage.UpdateBlob();
            tableStorage.TableCRUD();

            Console.ReadLine();
        }

        
    }
}
