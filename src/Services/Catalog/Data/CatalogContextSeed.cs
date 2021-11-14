using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Seed
{
    public class CatalogContextSeed 
    {
        public static void SeedData(IMongoCollection<Product> productsCollection)
        {
            bool isProductExists = productsCollection.Find(f => true).Any();
            {
                if(!isProductExists)
                {
                    productsCollection.InsertMany(GetProductSeed());
                }
            }
        }
        public static IEnumerable<Product> GetProductSeed() 
        {
            return new List<Product>  {
                new Product {
                    Name = "Apple IPhone",
                    Category = "Mobile Phones",
                    Description = "Mobile Phone",
                    ImageFile = "",
                    Price = 50.00M
                },
                new Product {
                    Name = "Mi Note 8",
                    Category = "Mobile Phones",
                    Description = "Mobile Phone",
                    ImageFile = "",
                    Price = 60.00M
                },
                new Product {
                    Name = "Samsung Phone Xolo",
                    Category = "Mobile Phones",
                    Description = "Mobile Phone",
                    ImageFile = "",
                    Price = 50.00M
                }
            };
        }
    }
}