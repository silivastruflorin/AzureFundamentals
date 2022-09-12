using System;
using System.IO;
using AzureTangyFunc.Models;
using AzureTangyFunc.Repository.Config;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace AzureTangyFunc
{
    public class OnImageResized
    {
        private readonly ICosmosAPIForMongoContext _context;
        public OnImageResized(ICosmosAPIForMongoContext context)
        {
            _context = context;
        }
        [FunctionName("OnImageResized")]
        public void Run([BlobTrigger("dotnetmastery-images-resized/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            var builder = new FilterDefinitionBuilder<SalesRequest>();
            var filter = builder.Eq(o => o.Id, name);

            //update one field
            var updaDefinition = Builders<SalesRequest>.Update.Set(obj => obj.Status, "Completed");
            _context.UpdateItemIntoDb(filter, updaDefinition);
        }
    }
}
