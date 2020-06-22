using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class ErrorLog
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("error_code")]
        [BsonRepresentation(BsonType.Int64)]
        public long ErrorCode { get; set; } = 0;

        [BsonElement("message")]
        [BsonRepresentation(BsonType.String)]
        public string Message { get; set; } = string.Empty;

        [BsonElement("source")]
        [BsonRepresentation(BsonType.String)]
        public string Source { get; set; } = string.Empty;

        [BsonElement("stack_trace")]
        [BsonRepresentation(BsonType.String)]
        public string StackTrace { get; set; } = string.Empty;

        [BsonElement("created_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
