using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json.Linq;

namespace Kaio.Core.MongoDb
{
    public static class MongoExtensions
    {


        public static BsonDocument ToMatchDocument(this IMongoQuery query)
        {
            return new BsonDocument
                {
                    {
                        "$match",query.ToBsonDocument()
                    }
                };
        }


        public static BsonDocument ToGroupDocument(this IMongoGroupBy fieldsGroupBy)
        {

            return ToGroupDocument(fieldsGroupBy, null);
        }

        public static BsonDocument ToGroupDocument(this IMongoGroupBy fieldsGroupBy, string collectionName)
        {

            var _groupBy = new BsonDocument();
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                _groupBy.Add(collectionName, string.Format("${0}", collectionName));
            }
            else
            {
                foreach (string _name in fieldsGroupBy.ToBsonDocument().Names)
                {
                    _groupBy.Add(new BsonElement(_name, string.Format("${0}", _name)));
                }
            }
           

            var _sums = new BsonDocument("_id",_groupBy);
            foreach (string _name in fieldsGroupBy.ToBsonDocument().Names)
            {
                _sums.Add(_name, new BsonDocument("$sum", string.Format("${0}", _name)));
            }

            return new BsonDocument("$group", _sums);
        }

       


        public static BsonDocument ToGroupDocument<T>(this IMongoFields fields)
        {

            var _coll = GetCollectionName<T>();

            var _sums = new BsonDocument { { "_id", new BsonDocument(_coll, string.Format("${0}", _coll)) } };

            foreach (string _name in fields.ToBsonDocument().Names)
            {
                _sums.Add(_name, new BsonDocument("$sum", string.Format("${0}", _name)));
            }

            return new BsonDocument("$group", _sums);
        }




        public static List<T> GetResultsAs<T>(this IEnumerable<BsonDocument> documents)
        {
            if (documents != null)
            {
                return documents.Select(_document => BsonSerializer.Deserialize<T>(_document)).ToList();
            }
            return new List<T>();
        }


        public static T GetResultAs<T>(this IEnumerable<BsonDocument> documents)
        {
            return GetResultsAs<T>(documents).SingleOrDefault();
        }


        public static dynamic ToDynamic(this BsonDocument doc)
        {
            var _json = doc.ToJson();
            dynamic _obj = JToken.Parse(_json);
            return _obj;
        }

        public static string GetCollectionName<T>()
        {
            var _att = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionName));
            string _collectionName = _att != null ? ((CollectionName)_att).Name : typeof(T).Name;

            if (string.IsNullOrEmpty(_collectionName))
            {
                throw new ArgumentException("Collection name cannot be empty for this entity");
            }
            return _collectionName;
        }

        public static string GetElementName<T>(string propertyName)
        {
            BsonClassMap _classMap = BsonClassMap.LookupClassMap(typeof(T));
            BsonMemberMap _memberMap = _classMap.GetMemberMap(propertyName);

            if (_memberMap == null)
                throw new ArgumentNullException(string.Format("The element name for property {0} could not be found for class type {1}.", propertyName, typeof(T).FullName));

            return _memberMap.ElementName;
        }

        public static void MapAutoValue<T>(this T obj)
        {
            Type _type = obj.GetType();
            foreach (var _p in _type.GetProperties().Where(_p => _p.GetCustomAttributes(false)
                .Any(x => x is BsonAutoTimestampAttribute)))
            {
                _p.SetValue(obj, DateTime.UtcNow, null);
            }
        }

        public static IMongoUpdate MapAutoValue<T>(this IMongoUpdate u)
        {

            Type _type = typeof(T);

            var _updates = new List<IMongoUpdate> { u };
            _updates.AddRange(_type.GetProperties().Where(_p => _p.GetCustomAttributes(false).Any(x => x is BsonAutoTimestampAttribute)).Select(_p => Update.Set(GetElementName<T>(_p.Name), DateTime.UtcNow)).Cast<IMongoUpdate>());

            return Update.Combine(_updates);

        }

    }
}
