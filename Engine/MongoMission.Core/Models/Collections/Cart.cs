using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoMission.Core.Models.Collections.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Models.Collections
{
    [BsonIgnoreExtraElements]
    [Serializable]
    public class Cart : BaseEntity
    {
        [BsonId, BsonElement("user_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; }
        [BsonId, BsonElement("product_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ProductId { get; set; }
        [BsonId, BsonElement("quantity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }
    }
}
