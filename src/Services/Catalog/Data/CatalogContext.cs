using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Catalog.API.Entities;
using Catalog.API.Seed;

namespace Catalog.API.Data 
{
    public class CatalogContext: ICatalogContext
    {
        CatalogContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings.DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings.CollectionName"));
            Products =  CatalogSeed.GetProductSeed();
        }

        public IMongoCollection<Product> Products {get;}

        IMongoCollection<Product> ICatalogContext.Products => throw new System.NotImplementedException();
    }
    
}