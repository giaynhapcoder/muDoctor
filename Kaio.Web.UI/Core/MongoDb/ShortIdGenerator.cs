using Kaio.Core;
using MongoDB.Bson.Serialization;

namespace Kaio.Web.UI.Core.MongoDb
{
    public class ShortIdGenerator : IIdGenerator
    {
        public object GenerateId(object container, object document)
        {
            return Utils.NewId();
        }

        public bool IsEmpty(object id)
        {
            return string.IsNullOrEmpty(id.ToString());
        }
    }
}
