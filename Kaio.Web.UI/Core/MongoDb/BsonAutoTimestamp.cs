using System;

namespace MongoDB.Bson.Serialization.Attributes
{


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field )]
    public class BsonAutoTimestampAttribute : Attribute, IBsonClassMapAttribute
    {
        
     

        public void Apply(BsonClassMap classMap)
        {
            throw new NotImplementedException();
        }
    }
}
