using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Kaio.Core.MongoDb
{
    public abstract class IObject
    {
        protected IObject()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonProperty("name")]
        [BsonIgnoreIfDefault]
        [BsonElement("nm")]
        public string Name { get; set; }


        [JsonIgnore]
        [BsonIgnoreIfDefault]
        [BsonElement("_sid")]
        public string ShortId { get; set; }

        [JsonIgnore]
        [BsonIgnoreIfNull]
        [BsonElement("tt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("created")]
        [BsonIgnore]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Created
        {
            get
            {
                var _oid = ObjectId.Empty;
                ObjectId.TryParse(Id, out _oid);
                return _oid.CreationTime;
            }
            set { throw new NotImplementedException(); }
        }
    }

    public abstract class IEntity
    {
        protected IEntity()
        {

            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
            Id = ObjectId.GenerateNewId().ToString();
        }

        /*[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]*/
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonIgnoreIfDefault]
        [BsonElement("nm")]
        public string Name { get; set; }

        [BsonIgnoreIfDefault]
        [BsonElement("_sid")]
        public string ShortId { get; set; }


        [BsonElement("crt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Created { get; set; }


        [BsonElement("lt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastUpdated { get; set; }


    }
}
