using System.Runtime.Serialization;

namespace Kaio.Web.UI
{
    [DataContract]
    public enum AjaxResultInlineMode
    {
        [EnumMember(Value = "replace")]
        Replace,
        [EnumMember(Value = "replaceWith")]
        ReplaceWith,
        [EnumMember(Value = "append")]
        Append,
        [EnumMember(Value = "before")]
        InsertBefore,
        [EnumMember(Value = "after")]
        InsertAfter,


    }
}