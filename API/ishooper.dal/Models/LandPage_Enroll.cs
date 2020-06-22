using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class LandPage_Enroll
    {

        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonRequired]
        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("telephone")]
        [BsonRepresentation(BsonType.String)]
        public string Telephone { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("occupation")]
        [BsonRepresentation(BsonType.Int32)]
        public int Occupation { get; set; } = 0;

        [BsonRequired]
        [BsonElement("created_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
