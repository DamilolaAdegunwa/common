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
    public class Comment: BaseEntity
    {
        [BsonElement("message"), BsonRepresentation(BsonType.String)]
        public string Message { get; set; }


		public Comment() { }
		public void Deconstruct(out string _Message)
		{
			_Message = Message;
		}
		public void Deconstruct(
			out ObjectId _Id,
			out DateTime _DateCreated,
			out ObjectId? _CreatedByUserId,
			out bool _IsDeleted,
			out DateTime? _DateDeleted,
			out ObjectId? _DeletedByUserId,
			out DateTime? _DateModified,
			out ObjectId? _ModifiedByUserId,


			out string _Message

			)
		{
			_Id = Id;
			_DateCreated = DateCreated;
			_CreatedByUserId = CreatedByUserId;
			_IsDeleted = IsDeleted;
			_DateDeleted = DateDeleted;
			_DeletedByUserId = DeletedByUserId;
			_DateModified = DateModified;
			_ModifiedByUserId = ModifiedByUserId;

			_Message = Message;
		}
	}
}
