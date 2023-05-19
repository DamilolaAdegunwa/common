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


		public void Deconstruct(
			out string _FullName,
			out DateTime _DateOfBirth,
			out string _Address,
			out string _PhoneNumber,
			out string _Email
			)
		{
			_FullName = FullName;
			_DateOfBirth = DateOfBirth;
			_Address = Address;
			_PhoneNumber = PhoneNumber;
			_Email = Email;
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


			out string _FullName,
			out DateTime _DateOfBirth,
			out string _Address,
			out string _PhoneNumber,
			out string _Email
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

			_FullName = FullName;
			_DateOfBirth = DateOfBirth;
			_Address = Address;
			_PhoneNumber = PhoneNumber;
			_Email = Email;
		}
	}
}
