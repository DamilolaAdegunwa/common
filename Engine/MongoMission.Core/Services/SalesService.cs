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
using MongoMission.Core.Services.Interfaces;
using MongoMission.Core.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace MongoMission.Core.Services
{
    public class SalesService : ISalesService
    {
        private readonly AppSettings _appSettings;
        private readonly IProcessor _processor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SalesService> _logger;
        private readonly string _fullClassName;
        
        public SalesService(IOptions<AppSettings> options, IProcessor processor, IUnitOfWork unitOfWork, ILogger<SalesService> logger) 
        {
            _appSettings = options.Value;
            _processor = processor;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fullClassName = $"{this.GetType().Namespace}.{this.GetType().Name}";
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}