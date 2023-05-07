using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MongoMission.Core.Models;
using Amazon.Runtime.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.Interfaces;

namespace MongoMission.Core.Services
{
    public class SampleService : ISampleService
    {
        private readonly AppSettings _appSettings;
        public SampleService(IOptions<AppSettings> options) 
        {
            _appSettings = options.Value;
        }

        private IMongoCollection<Product> ProductCollection()
        {
            string connStr = _appSettings.DatabaseConnection.ConnectionString;
            var databaseName = MongoUrl.Create(connStr).DatabaseName;
            var mongoClient = new MongoClient(connStr);
            var database = mongoClient.GetDatabase(databaseName);
            var productCollection = database.GetCollection<Product>("product");//collection <=> table

            return productCollection;
        }
        public List<Product> GetProducts()
        {
            var productCollection = ProductCollection();
            var filterdefinition = Builders<Product>.Filter.Empty;
            var products = productCollection.Find(filterdefinition).ToList();

            return products;
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                var productCollection = ProductCollection();
                productCollection.InsertOne(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}