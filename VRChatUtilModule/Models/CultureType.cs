using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Models
{
    /// <summary>
    /// 言語タイプ
    /// </summary>
    public enum CultureType
    {
        [EnumExtension.LocaleIdAttrebute("ja-JP")]
        Japanese,

        [EnumExtension.LocaleIdAttrebute("en-US")]
        English
    }
}