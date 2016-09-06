using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJobTest
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }

        // Function to get all png files added in input container
        // and rename the file in output container
        private static void RenameFile(
            [BlobTrigger("input/{blob-name}.png")] Stream input,
            [BlobTrigger("output/processed_{blob-name}_final.png")] Stream output)
        {
            input.CopyTo(output);
        }
    }
}
