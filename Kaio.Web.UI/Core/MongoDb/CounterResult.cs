using MongoDB.Bson.Serialization.Attributes;

namespace Kaio.Core.MongoDb
{
    public class CounterResult
    {

        [BsonElement("_id")]
        public object Id { get; set; }

        [BsonElement("value")]
        public double Value { get; set; }
    }
}
