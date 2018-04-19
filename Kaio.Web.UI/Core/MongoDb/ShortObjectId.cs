using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Kaio.Core.MongoDb
{
    public class ShortObjectId : IIdGenerator
    {

        public object GenerateId(object container, object document)
        {

            var oId = ObjectId.GenerateNewId();

            var date = oId.CreationTime;

            var time = date.Ticks;

            var counter = int.Parse(oId.ToString() .Substring(-6), NumberStyles.Number);

            return Utils.NewId();
        }

        public bool IsEmpty(object id)
        {
            return string.IsNullOrEmpty(id.ToString());
        }
    }
}
