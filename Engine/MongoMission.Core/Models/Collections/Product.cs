using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoMission.Core.Models.Collections.Base;

namespace MongoMission.Core.Models.Collections
{
    [Serializable]
    public class Product: BaseEntity
    {
        [BsonElement("product_code"), BsonRepresentation(BsonType.String)]
        public string ProductCode { get; set; }
        [BsonElement("product_name"), BsonRepresentation(BsonType.String)]
        public string ProductName { get; set; }
        [BsonElement("price"), BsonRepresentation(BsonType.Decimal128)]
        public string Price { get; set; }
    }
}
