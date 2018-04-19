using MongoDB.Bson.Serialization.Attributes;

namespace Kaio.Core.MongoDb
{
    public abstract class MongoObject
    {
        [BsonId]
        [BsonElement("_id")]
        public string Id { get; set; }
        public abstract void Save();
        public abstract void Remove();

    }
}
