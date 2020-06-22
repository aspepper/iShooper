using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class Profession
    {

        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; } = string.Empty;

        [BsonElement("status")]
        [BsonDefaultValue(true)]
        [BsonIgnoreIfDefault(false)]
        public bool Status { get; set; } = true;

        [BsonElement("administrative")]
        [BsonDefaultValue(false)]
        [BsonIgnoreIfDefault(false)]
        public bool Administrative { get; set; } = false;

        [BsonElement("created_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("modified_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
