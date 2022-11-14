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
        /// @enum�� <see cref="DiscriptionAttribute"/> �� <see cref="string"/> Description �� �����´�.
        /// </summary>
        /// <summary>
        /// @enum�� DiscriptionAttribute �� ������ string���� �����´�
        /// </summary>
        public static string GetDescription(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //�ش� text ���� �迭�� ������ �ɴϴ�.
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
        /// @enum�� <see cref="EnumDisplayNameAttribute"/> �� <see cref="string"/> Name �� �����´�.
        /// </summary>
        public static string GetEnumDisplayName(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //�ش� text ���� �迭�� ������ �ɴϴ�.
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
        /// @enum�� <see cref="EnumDisplayImageAttribute"/> �� <see cref="Bitmap"/> Bitmap�� �����´�.
        /// </summary>
        public static Bitmap? GetEnumDisplayImage(Enum @enum)
        {
            Type type = @enum.GetType();
            MemberInfo[] memInfo = type.GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                //�ش� text ���� �迭�� ������ �ɴϴ�.
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
        /// <typeparamref name="TEnum"/>(<see langword="enum"/>)�� ��Ͽ��� �Ҵ�� ������ ������ ����� �����ɴϴ�.
        /// <br/><see cref="Enum.GetValues(Type)"/>�� ����(-) ���� �Ҵ�� <typeparamref name="TEnum"/>�� �� ������ �ҷ����µ�
        /// <br/>�� �޼ҵ�� �������� ���� �����մϴ�.
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
