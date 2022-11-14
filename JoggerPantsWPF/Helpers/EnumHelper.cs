using JoggerPantsWPF.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace JoggerPantsWPF.Helpers
{
    public static class EnumHelper
    {
        #region Description
        /// <summary>
        /// @enum의 <see cref="DiscriptionAttribute"/> 의 <see cref="string"/> Description 을 가져온다.
        /// </summary>
        /// <summary>
        /// @enum의 DiscriptionAttribute 의 내용을 string으로 가져온다
        /// </summary>
        public static string GetDescription(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //해당 text 값을 배열로 추출해 옵니다.
                var attr = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                if (attr != null)
                {
                    return ((DescriptionAttribute)attr).Description;
                }
            }
            return "";
        }
        #endregion

        #region EnumDisplayName
        /// <summary>
        /// @enum의 <see cref="EnumDisplayNameAttribute"/> 의 <see cref="string"/> Name 을 가져온다.
        /// </summary>
        public static string GetEnumDisplayName(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //해당 text 값을 배열로 추출해 옵니다.
                var attr = memInfo[0].GetCustomAttributes(typeof(EnumDisplayNameAttribute), false).FirstOrDefault();
                if (attr != null)
                {
                    return ((EnumDisplayNameAttribute)attr).Name;
                }
            }
            return "";
        }
        #endregion

        #region EnumDisplayImage
        /// <summary>
        /// @enum의 <see cref="EnumDisplayImageAttribute"/> 의 <see cref="Bitmap"/> Bitmap을 가져온다.
        /// </summary>
        public static Bitmap? GetEnumDisplayImage(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //해당 text 값을 배열로 추출해 옵니다.
                var attr = memInfo[0].GetCustomAttributes(typeof(EnumDisplayImageAttribute), false).FirstOrDefault();
                if (attr != null)
                {
                    return ((EnumDisplayImageAttribute)attr).Bitmap;
                }
            }
            return null;
        }
        #endregion

        #region EnumParser
        public static bool TryParseByInt<TEnum>(int input, out TEnum? output) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), input))
            {
                foreach (TEnum item in Enum.GetValues(typeof(TEnum)))
                {
                    if (input != Convert.ToInt32(item))
                        continue;

                    output = item;
                    return true;
                }
            }

            output = default;
            return false;
        }
        #endregion

        #region GetOrderedList
        /// <summary>
        /// <typeparamref name="TEnum"/>(<see langword="enum"/>)의 목록에서 할당된 정수값 순으로 목록을 가져옵니다.
        /// <br/><see cref="Enum.GetValues(Type)"/>은 음수(-) 값이 할당된 <typeparamref name="TEnum"/>을 후 순위로 불러오는데
        /// <br/>이 메소드는 음수값을 먼저 나열합니다.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetOrderedList<TEnum>() where TEnum : Enum
        {
            var EnumValues = ((TEnum[])Enum.GetValues(typeof(TEnum))).OrderBy(i => (TEnum)i);
            return EnumValues;
        }
        #endregion
    }
}
