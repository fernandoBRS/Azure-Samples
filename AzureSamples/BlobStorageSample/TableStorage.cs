using System;
using System.Configuration;
using Sandboxable.Microsoft.WindowsAzure.Storage;
using Sandboxable.Microsoft.WindowsAzure.Storage.Blob;
using Sandboxable.Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageSample
{
    public class TableStorage
    {
        public void TableCRUD()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnStr"]);

            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("orders");
            table.CreateIfNotExists();

            InsertOrUpdateOrder(table);
            InsertOrUpdateRecord(table);
            FilterOrders(table);
        }

        private static void InsertOrUpdateOrder(CloudTable table)
        {
            var order = new Order("Fernando de Oliveira", "20161103")
            {
                OrderNumber = "206",
                ShippedDate = new DateTime(2016, 11, 3),
                RequiredDate = new DateTime(2016, 11, 7),
                Status = "shipped"
            };

            var insert = TableOperation.InsertOrReplace(order);
            table.Execute(insert);

            Console.WriteLine("Item inserted or updated in Table Storage.");
        }

        private static void InsertOrUpdateRecord(CloudTable table)
        {
            var order1 = new Order("Fernando de Oliveira", "20161103")
            {
                OrderNumber = "206",
                ShippedDate = new DateTime(2016, 11, 3),
                RequiredDate = new DateTime(2016, 11, 7),
                Status = "shipped"
            };

            var order2 = new Order("Fernando de Oliveira", "20161210")
            {
                OrderNumber = "207",
                ShippedDate = new DateTime(2016, 12, 11),
                RequiredDate = new DateTime(2016, 12, 13),
                Status = "pending"
            };

            var order3 = new Order("Fernando de Oliveira", "20161218")
            {
                OrderNumber = "208",
                ShippedDate = new DateTime(2016, 12, 19),
                RequiredDate = new DateTime(2016, 12, 22),
                Status = "open"
            };

            var batchOperation = new TableBatchOperation();

            batchOperation.InsertOrReplace(order1);
            batchOperation.InsertOrReplace(order2);
            batchOperation.InsertOrReplace(order3);

            table.ExecuteBatch(batchOperation);

            Console.WriteLine("Items inserted or updated with batch operation.");
        }

        private static void FilterOrders(CloudTable table)
        {
            var query = new TableQuery<Order>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", 
                QueryComparisons.Equal, "Fernando de Oliveira"));

            foreach (var item in table.ExecuteQuery(query))
            {
                Console.WriteLine($"{item.RowKey}: {item.Status}");
            }
        }
    }
}
