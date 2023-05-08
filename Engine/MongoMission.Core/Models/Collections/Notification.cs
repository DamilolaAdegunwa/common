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
    public  class Notification: BaseEntity
    {
        [BsonElement("email_message"), BsonRepresentation(BsonType.String)]
        public string EmailMessage { get; set; }
        [BsonElement("sms_message"), BsonRepresentation(BsonType.String)]
        public string SMSMessage { get; set; }
        [BsonElement("email_delivered"), BsonRepresentation(BsonType.Boolean)]
        public bool EmailDelivered { get; set; }
        [BsonElement("sms_delivered"), BsonRepresentation(BsonType.Boolean)]
        public string SMSDelivered { get; set; }
    }
}
