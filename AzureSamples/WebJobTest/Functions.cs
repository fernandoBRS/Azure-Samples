using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJobTest
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage(
            [QueueTrigger("queue")] string message, 
            TextWriter log)
        {
            log.WriteLine(message);
        }

        // Function to get all png files added in input container
        // and rename the file in output container
        public static void RenameFile(
            [BlobTrigger("input/{blob-name}.png")] Stream input,
            [BlobTrigger("output/processed_{blob-name}_final.png")] Stream output)
        {
            input.CopyTo(output);
        }
    }
}
