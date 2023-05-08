using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoMission.Core.Models.Collections.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MongoMission.Core.Models.Collections
{
    [BsonIgnoreExtraElements]
    [Serializable]
    [Table(nameof(Wallet))]
    public class Wallet : BaseEntity
    {
        [BsonElement("user_id"), BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }
        [BsonElement("balance"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Balance { get; set; }
        [BsonElement("currency"), BsonRepresentation(BsonType.String)]
        public string Currency { get; set; }
        [BsonIgnore]
        [BsonElement("transactions"), BsonRepresentation(BsonType.Array)]
        public List<Transaction> Transactions { get; set; }
    }
}
