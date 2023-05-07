using Microsoft.Extensions.Options;
using MongoMission.Core.Models;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.RepositorIes.Interfaces;
using MongoMission.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.RepositorIes
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        private readonly AppSettings _appSettings;
        public ProductRepository(IOptions<AppSettings> options) : base(options, AppConstants.ProductCollectionName) { }
    }
}
