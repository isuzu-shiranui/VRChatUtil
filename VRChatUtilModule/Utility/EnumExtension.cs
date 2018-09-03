using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VRChatUtilModule.Utility
{
    public static class EnumExtension
    {
        /// <inheritdoc />
        /// <summary>
        /// 表示名カスタム属性
        /// </summary>
        [AttributeUsage(AttributeTargets.Field)]
        public sealed class DisplayNameAttrebute : Attribute
        {
            public string DisplayName { get; }

            public DisplayNameAttrebute(string displayName) => this.DisplayName = displayName;
        }

        /// <summary>
        /// 表示名取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum value) => value.GetAttribute<DisplayNameAttrebute>()?.DisplayName ?? value.ToString();

        /// <inheritdoc />
        /// <summary>
        /// ロケールIDカスタム属性
        /// </summary>
        [AttributeUsage(AttributeTargets.Field)]
        public sealed class LocaleIdAttrebute : Attribute
        {
            public string LocaleId { get; }

            public LocaleIdAttrebute(string localeId) => this.LocaleId = localeId;
        }

        /// <summary>
        /// ロケールID取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetLocaleId(this Enum value) => value.GetAttribute<LocaleIdAttrebute>()?.LocaleId ?? value.ToString();

        /// <summary>
        /// 属性情報取得
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            //リフレクションを用いて列挙体の型から情報を取得
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            //指定した属性のリスト
            IEnumerable<TAttribute> attributes = fieldInfo.GetCustomAttributes(typeof(TAttribute), false)
                .OfType<TAttribute>();
            //属性がなかった場合、空を返す
            TAttribute[] enumerable = attributes as TAttribute[] ?? attributes.ToArray();
            return (enumerable?.Count() ?? 0) <= 0 ? null : enumerable.First();
        }
    }
}