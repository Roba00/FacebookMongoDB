using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo363.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Message { get; set; } = null!;

        public DateTime Timestamp { get; set; }
    }
}
