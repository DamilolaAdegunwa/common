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
    public class Invoice: BaseEntity
    {
        [BsonElement("file_url"), BsonRepresentation(BsonType.String)]
        public string FileUrl { get; set; }
    }
}
