using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnetApi.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}