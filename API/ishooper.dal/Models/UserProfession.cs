using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class UserProfession
    {

        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; } = new ObjectId();

        [BsonElement("profession_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ProfessionId { get; set; } = new ObjectId();

        [BsonElement("price")]
        [BsonRepresentation(BsonType.Double)]
        public double Price { get; set; } = 20;

        [BsonElement("integrated_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime IntegratedDate { get; set; } = new DateTime();

        [BsonElement("is_deleted")]
        [BsonDefaultValue(false)]
        [BsonIgnoreIfDefault(false)]
        public bool IsDeleted { get; set; } = false;

        [BsonElement("deleted_date")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDefaultValue("1900-01-01T01:01:10-03:00")]
        [BsonIgnoreIfDefault(true)]
        public DateTime DeletedDate { get; set; } = DateTime.MinValue;

    }
}
