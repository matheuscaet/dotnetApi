using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnetApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}