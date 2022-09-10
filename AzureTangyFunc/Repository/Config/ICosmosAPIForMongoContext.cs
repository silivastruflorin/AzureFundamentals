using AzureTangyFunc.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTangyFunc.Repository.Config
{
    public interface ICosmosAPIForMongoContext
    {
        void InsertItemIntoDb(SalesRequest saleRequest);

        void UpdateItemIntoDb(FilterDefinition<SalesRequest> filter, UpdateDefinition<SalesRequest> saleRequest);

        IMongoCollection<SalesRequest> GetSalesCollection();

    }
}
