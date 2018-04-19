using System.Runtime.Serialization;

namespace Kaio.Web.UI
{
    [DataContract]
    public enum AjaxRequestDataType
    {
        [EnumMember(Value = "html")]
        Html,
        [EnumMember(Value = "json")]
        Json,
        Jsonp,
        [EnumMember(Value = "script")]
        Script,
        [EnumMember(Value = "xml")]
        Xml,
        Text
    }
}