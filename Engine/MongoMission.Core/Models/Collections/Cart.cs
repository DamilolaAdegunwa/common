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

        public Cart() { }
        public void Deconstruct(out ObjectId _UserId, out ObjectId _ProductId, decimal _Quantity)
        {
            _UserId = UserId;
			_ProductId = ProductId;
            _Quantity = Quantity;
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


			out ObjectId _UserId, 
            out ObjectId _ProductId, 
            out decimal _Quantity
            
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

			_UserId = UserId;
			_ProductId = ProductId;
			_Quantity = Quantity;
		}
	}
}
