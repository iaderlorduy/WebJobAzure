using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;

namespace WebJobTest
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var conecction = CloudConfigurationManager.GetSetting("AzureWebJobsDashboard");
            var storageAccount = CloudStorageAccount.Parse(conecction);

            var createClound = storageAccount.CreateCloudQueueClient();
            var queueReference = createClound.GetQueueReference("afro");
            var queueReferenceposion = createClound.GetQueueReference("afro-poison");

            queueReference.CreateIfNotExists();
            queueReferenceposion.CreateIfNotExists();

            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}

