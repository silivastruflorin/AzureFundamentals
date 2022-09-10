using System;
using AzureTangyFunc.Models;
using AzureTangyFunc.Repository.Config;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureTangyFunc
{
    public class FromQueueToMongoDb
    {
        private ICosmosAPIForMongoContext _context;

        public FromQueueToMongoDb(ICosmosAPIForMongoContext context)
        {
            _context = context;
        }

        [FunctionName("FromQueueToMongoDb")]
        public void Run([QueueTrigger("SalesRequestInBound", Connection = "AzureWebJobsStorage")]SalesRequest myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            _context.InsertItemIntoDb(myQueueItem);
        }
    }
}
