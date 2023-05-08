using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Models.Collections.Base
{
    public class BaseEntity
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        #region creation
        [BsonId, BsonElement("date_created"), BsonRepresentation(BsonType.DateTime)]
        public DateTime DateCreated { get; set; }
        [BsonId, BsonElement("created_by_user_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? CreatedByUserId { get; set; }
        #endregion

        #region deletion
        [BsonId, BsonElement("is_deleted"), BsonRepresentation(BsonType.Boolean)]
        public bool IsDeleted { get; set; }
        [BsonId, BsonElement("date_deleted"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? DateDeleted { get; set; }
        [BsonId, BsonElement("deleted_by_user_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? DeletedByUserId { get; set; }
        #endregion

        #region modification
        [BsonId, BsonElement("date_modified"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? DateModified { get; set; }
        [BsonId, BsonElement("modified_by_user_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? ModifiedByUserId { get; set; }
        #endregion
    }
}
