using AzureTangyFunc.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace AzureTangyFunc.Repository.Config
{
    public class CosmosAPIForMongoContext : ICosmosAPIForMongoContext
    {
        public readonly IMongoDatabase _database;
        public readonly IMongoCollection<SalesRequest> _salesCollection;
        public CosmosAPIForMongoContext(string connectionString, string databaseName)
        {
     
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            _database = mongoClient.GetDatabase(databaseName);
            _salesCollection = _database.GetCollection<SalesRequest>("SaleRequestCollection");
        }

        public async void InsertItemIntoDb(SalesRequest saleRequest)
        {
            await _salesCollection.InsertOneAsync(saleRequest);
        }

        public async void UpdateItemIntoDb(FilterDefinition<SalesRequest> filter,  UpdateDefinition<SalesRequest> saleRequest)
        {
            await _salesCollection.UpdateOneAsync(filter, saleRequest);
        }

        public IMongoCollection<SalesRequest> GetSalesCollection()
        {
            return _salesCollection;
        }
    }
}
