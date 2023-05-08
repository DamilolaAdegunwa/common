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
    public class Customer: BaseEntity
    {
        [BsonElement, BsonRepresentation(BsonType.String)]
        public string FullName { get; set; }
        [BsonElement, BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [BsonElement, BsonRepresentation(BsonType.String)]
        public string Address { get; set; }
        [BsonElement, BsonRepresentation(BsonType.String)]
        public string PhoneNumber { get; set; }
        [BsonElement, BsonRepresentation(BsonType.String)]
        public string Email { get; set; }
    }
}
