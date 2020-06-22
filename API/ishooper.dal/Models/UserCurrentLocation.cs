using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ishooper.Dal.Models
{

    [BsonIgnoreExtraElements]
    public class UserCurrentLocation
    {

        [BsonId]
        [BsonElement("_id", Order = 1)]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonRequired]
        [BsonElement("user", Order = 2)]
        public ObjectId UserId { get; set; } = new ObjectId();

        [BsonRequired]
        [BsonElement("latitude", Order = 3)]
        public double Latitude { get; set; } = 0;

        [BsonRequired]
        [BsonElement("longitude", Order = 3)]
        public double Longitude { get; set; } = 0;


    }
}
