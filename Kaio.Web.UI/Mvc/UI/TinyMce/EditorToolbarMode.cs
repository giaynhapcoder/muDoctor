using System.Runtime.Serialization;

namespace Kaio.Web.UI
{

    public enum EditorToolbarMode
    {
        [EnumMember(Value = "small")]
        Small,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "full")]
        Full
    }
}
