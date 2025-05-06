using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Demo_EFC.Model
{
    public class QueryLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string CommandText { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
