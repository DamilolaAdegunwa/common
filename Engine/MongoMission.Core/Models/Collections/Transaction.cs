using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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
    public class Transaction : BaseEntity
    {
        [BsonElement("transaction_id"), BsonRepresentation(BsonType.String)]
        public string TransactionId { get; set; }
        [BsonElement("wallet_id"), BsonRepresentation(BsonType.String)]
        public string WalletId { get; set; }
        [BsonElement("type"), BsonRepresentation(BsonType.String)]
        public string Type { get; set; }
        [BsonElement("amount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Amount { get; set; }
        [BsonElement("currency"), BsonRepresentation(BsonType.String)]
        public string Currency { get; set; }
        [BsonElement("date"), BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
}
