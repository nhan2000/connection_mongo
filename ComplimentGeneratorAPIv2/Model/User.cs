using MongoDB.Bson;

namespace ComplimentGeneratorAPIv2.Model
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string? Content { get; set; }
    }
}
