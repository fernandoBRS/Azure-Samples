using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandboxable.Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageSample
{
    public class Order: TableEntity
    {
        public Order(string customerName, String orderDate)
        {
            PartitionKey = customerName;
            RowKey = orderDate;
        }

        public Order() { }
       
        public string OrderNumber { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }
    }
}
