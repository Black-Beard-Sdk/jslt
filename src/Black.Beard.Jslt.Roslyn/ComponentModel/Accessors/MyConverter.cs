using System;
using System.ComponentModel;
using System.Globalization;

namespace Bb.ComponentModel.Accessors
{

    /// <summary>
    /// My Converter
    /// </summary>
    public class MyConverter
    {

        /// <summary>
        /// The default value
        /// </summary>
        public static string Default = "A5BA2123-213E-4AE9-BD2F-6C13C34EA6FB";

        /// <summary>
        /// Serializes the specified value in string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Serialize(dynamic value)
        {

            if (value == null)
                return Default;

            Type type = value.GetType();

            if (type.IsEnum)
                return value.ToString();

            if (type == typeof(bool) || type == typeof(bool?))
                return value.ToString();

            if (type == typeof(byte) || type == typeof(byte?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(char) || type == typeof(char?))
                return char.ToString(value);

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return value.ToString();

            if (type == typeof(decimal) || type == typeof(decimal?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(double) || type == typeof(double?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(short) || type == typeof(short?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(int) || type == typeof(int?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(long) || type == typeof(long?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(sbyte) || type == typeof(sbyte?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(float) || type == typeof(float?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(ushort) || type == typeof(ushort?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(uint) || type == typeof(uint?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(ulong) || type == typeof(ulong?))
                return value.ToString(CultureInfo.CurrentCulture);

            IConvertible convertible = value as IConvertible;
            if (convertible != null)
                return convertible.ToString(CultureInfo.CurrentCulture);

            IFormattable formattable = value as IFormattable;
            if (formattable != null)
                return formattable.ToString(null, CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(value.GetType());
            string result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }


        /// <summary>
        /// Unserializes the specified string value in the specified type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        internal static dynamic Unserialize(string value, Type type)
        {

            if (value == Default)
                return null;

            if (type.IsEnum)
                return Enum.Parse(type, value);

            IConvertible convertible = value as IConvertible;

            if (type == typeof(bool) || type == typeof(bool?))
                return String.IsNullOrWhiteSpace(value) ? (bool?)null : convertible.ToBoolean(CultureInfo.CurrentCulture);

            if (type == typeof(byte) || type == typeof(byte?))
                return String.IsNullOrWhiteSpace(value) ? (byte?)null : convertible.ToByte(CultureInfo.CurrentCulture);

            if (type == typeof(char) || type == typeof(char?))
                return String.IsNullOrWhiteSpace(value) ? (char?)null : convertible.ToChar(CultureInfo.CurrentCulture);

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return String.IsNullOrWhiteSpace(value) ? (DateTime?)null : convertible.ToDateTime(CultureInfo.CurrentCulture);

            if (type == typeof(decimal) || type == typeof(decimal?))
                return String.IsNullOrWhiteSpace(value) ? (decimal?)null : convertible.ToDecimal(CultureInfo.CurrentCulture);

            if (type == typeof(double) || type == typeof(double?))
                return String.IsNullOrWhiteSpace(value) ? (double?)null : convertible.ToDouble(CultureInfo.CurrentCulture);

            if (type == typeof(short) || type == typeof(short?))
                return String.IsNullOrWhiteSpace(value) ? (short?)null : convertible.ToInt16(CultureInfo.CurrentCulture);

            if (type == typeof(int) || type == typeof(int?))
                return String.IsNullOrWhiteSpace(value) ? (int?)null : convertible.ToInt32(CultureInfo.CurrentCulture);

            if (type == typeof(long) || type == typeof(long?))
                return String.IsNullOrWhiteSpace(value) ? (long?)null : convertible.ToInt64(CultureInfo.CurrentCulture);

            if (type == typeof(sbyte) || type == typeof(sbyte?))
                return String.IsNullOrWhiteSpace(value) ? (sbyte?)null : convertible.ToSByte(CultureInfo.CurrentCulture);

            if (type == typeof(float) || type == typeof(float?))
                return String.IsNullOrWhiteSpace(value) ? (float?)null : convertible.ToSingle(CultureInfo.CurrentCulture);

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(ushort) || type == typeof(ushort?))
                return String.IsNullOrWhiteSpace(value) ? (ushort?)null : convertible.ToUInt16(CultureInfo.CurrentCulture);

            if (type == typeof(uint) || type == typeof(uint?))
                return String.IsNullOrWhiteSpace(value) ? (uint?)null : convertible.ToUInt32(CultureInfo.CurrentCulture);

            if (type == typeof(ulong) || type == typeof(ulong?))
                return String.IsNullOrWhiteSpace(value) ? (ulong?)null : convertible.ToUInt64(CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(type);
            string result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }

    }


}