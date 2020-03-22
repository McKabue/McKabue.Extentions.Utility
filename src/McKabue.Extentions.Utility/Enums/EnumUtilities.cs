using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace McKabue.Extentions.Utility.Enums
{
    public static class EnumUtilities
    {
        public static string GetDisplayName<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            if (@enum == null)
            {
                return string.Empty;
            }

            DisplayAttribute displayname = @enum.GetAttribute<DisplayAttribute>();
            if (displayname == null)
            {
                return @enum.ToString();
            }

            return displayname.Name;
        }

        public static string GetEnumMemberValue<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            if (@enum == null)
            {
                return string.Empty;
            }

            EnumMemberAttribute enumMember = @enum.GetAttribute<EnumMemberAttribute>();
            if (enumMember == null)
            {
                /// <summary>
                /// https://stackoverflow.com/a/3213790
                /// </summary>
                return (Convert.ChangeType(@enum, @enum.GetTypeCode())).ToString();
            }

            return enumMember.Value;
        }

        public static TEnum GetEnum<TEnum>(
            this string enumName, TEnum fallback = default) where TEnum : Enum
        {
            Enum.TryParse(typeof(TEnum), enumName, true, out object value);
            return value != null ? (TEnum)value : fallback;
        }

        public static bool EnumEqual<TEnum>(this TEnum @enum, int value) where TEnum : Enum
        {
            try
            {
                return Enum.IsDefined(typeof(TEnum), @enum) && @enum.ToString().EnumEqual<TEnum>(value);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool EnumEqual<TEnum>(this string enumName, int value) where TEnum : Enum
        {
            try
            {
                return (int)Enum.Parse(typeof(TEnum), enumName, ignoreCase: true) == value;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Dictionary<int, string> EnumDictionary<TEnum>(bool order = false, params TEnum[] excludes) where TEnum : Enum
        {
            excludes = excludes ?? new TEnum[] { };
            Dictionary<int, string> dict = new Dictionary<int, string>();
            string[] names = order ? GetOrderedEnumNames<TEnum>() : Enum.GetNames(typeof(TEnum));
            foreach (string name in names)
            {
                TEnum @enum = name.GetEnum<TEnum>();

                if (!excludes.Any(i => i.Equals(@enum)))
                    dict.Add(((int)Enum.Parse(typeof(TEnum), name)), @enum.GetDisplayName<TEnum>());
            }

            return dict;
        }

        /// <summary>
        /// Enums the get names.
        /// http://stackoverflow.com/a/25147675
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns></returns>
        public static string[] GetOrderedEnumNames<TEnum>()
        {
            IEnumerable<FieldInfo> f = typeof(TEnum).GetFields().Where(fi => fi.IsStatic).OrderBy(fi => ((OrderAttribute)fi.GetCustomAttributes(typeof(OrderAttribute), true)?.FirstOrDefault())?.Order);
            return f.Select(i => i.GetValue(null).ToString()).ToArray();
        }

        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        ///     http://stackoverflow.com/a/25109103
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            try
            {
                return enumValue?.GetType()
                            ?.GetMember(enumValue?.ToString())
                            ?.First()
                            ?.GetCustomAttribute<TAttribute>();
            }
            catch (Exception)
            {
                return null as TAttribute;
            }

        }
    }
}