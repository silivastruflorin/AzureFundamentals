using AzureTangyFunc;
using AzureTangyFunc.Repository.Config;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AzureTangyFunc
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("MongoDbConnection");
            string databaseName = Environment.GetEnvironmentVariable("MongoDatabaseName");
            builder.Services.AddSingleton<ICosmosAPIForMongoContext>(opt => new CosmosAPIForMongoContext(connectionString, databaseName));
           
            builder.Services.BuildServiceProvider();    
        }
    }
}
