using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class User
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
        [BsonElement("user")]
        [BsonRepresentation(BsonType.String)]
        public string UserLogon { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("telephone")]
        [BsonRepresentation(BsonType.String)]
        public string Telephone { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("gender")]
        [BsonRepresentation(BsonType.String)]
        public string Gender { get; set; } = string.Empty;

        [BsonRequired]
        [BsonElement("profile")]
        [BsonRepresentation(BsonType.Int32)]
        public int Profile { get; set; } = 0;

        [BsonRequired]
        [BsonElement("occupation")]
        public Profession Occupation { get; set; } = new Profession();

        [BsonElement("photo")]
        [BsonRepresentation(BsonType.String)]
        public string Photo { get; set; } = string.Empty;

        [BsonElement("calls")]
        [BsonRepresentation(BsonType.Int32)]
        public int Calls { get; set; } = 0;

        [BsonElement("points")]
        [BsonRepresentation(BsonType.Double)]
        public double Points { get; set; } = 0;

        [BsonElement("is_deleted")]
        [BsonDefaultValue(false)]
        [BsonIgnoreIfDefault(false)]
        public bool IsDeleted { get; set; } = false;

        [BsonRequired]
        [BsonElement("created_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonRequired]
        [BsonElement("modified_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [BsonElement("deleted_date")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDefaultValue("1900-01-01T01:01:10-03:00")]
        [BsonIgnoreIfDefault(true)]
        public DateTime DeletedDate { get; set; } = DateTime.MinValue;

    }
}
