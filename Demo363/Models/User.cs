using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Demo363.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Username { get; set; } = null!;

        public string DisplayName { get; set; } = null!;
    }
}
