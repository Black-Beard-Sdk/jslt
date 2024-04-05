using Oldtonsoft.Json.Linq;
using System;

namespace Bb.Expressions
{
    public static partial class CustomConverter
    {

        #region ToBoolean

        public static bool ToBoolean(JToken value)
        {
            return Convert.ToBoolean(value.Value<object>());
        }

        public static bool ToBoolean(JValue value)
        {
            return Convert.ToBoolean(value.Value);
        }

        public static bool ToBoolean(bool? value)
        {
            return value.HasValue ? value.Value : false;
        }

        [CLSCompliant(false)]
        public static bool ToBoolean(sbyte? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(char? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        public static bool ToBoolean(byte? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(short? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        [CLSCompliant(false)]
        public static bool ToBoolean(ushort? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(int? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        [CLSCompliant(false)]
        public static bool ToBoolean(uint? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(long? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        [CLSCompliant(false)]
        public static bool ToBoolean(ulong? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(float? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(double? value)
        {
            return value != 0;
        }

        public static bool ToBoolean(decimal? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        #endregion ToBoolean

        #region ToByte               

        [CLSCompliant(false)]
        public static sbyte ToSByte(JValue value)
        {
            return Convert.ToSByte(value.Value);
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(JToken value)
        {
            return Convert.ToSByte(value.Value<object>());
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(bool? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(sbyte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(char? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(byte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(short? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(ushort? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(int? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(uint? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(long? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(ulong? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(float? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(double? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(decimal? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(DateTime? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        #endregion ToByte

        #region ToChar

        [CLSCompliant(false)]
        public static char ToChar(JValue value)
        {
            return Convert.ToChar(value.Value);
        }

        public static char ToChar(JToken value)
        {
            return value.Value<char>();
        }

        public static char ToChar(bool? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(char? value)
        {
            return value.HasValue ? value.Value : '\0';
        }

        [CLSCompliant(false)]
        public static char ToChar(sbyte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(byte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(short? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        [CLSCompliant(false)]
        public static char ToChar(ushort? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(int? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        [CLSCompliant(false)]
        public static char ToChar(uint? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(long? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        [CLSCompliant(false)]
        public static char ToChar(ulong? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(float? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(double? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);

            return '\0';
        }

        public static char ToChar(decimal? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        #endregion ToChar

        #region ToInt16

        [CLSCompliant(false)]
        public static short ToInt16(JValue value)
        {
            return Convert.ToInt16(value.Value);
        }

        public static short ToInt16(JToken value)
        {
            return value.Value<short>();
        }

        public static short ToInt16(bool? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(char? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        [CLSCompliant(false)]
        public static short ToInt16(sbyte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(byte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        [CLSCompliant(false)]
        public static short ToInt16(ushort? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(int? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        [CLSCompliant(false)]
        public static short ToInt16(uint? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(short? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(long? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        [CLSCompliant(false)]
        public static short ToInt16(ulong? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(float? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(double? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(decimal? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(DateTime? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        #endregion ToInt16        

        #region ToDateTime

        [CLSCompliant(false)]
        public static DateTime ToDateTime(JValue value)
        {
            return Convert.ToDateTime(value.Value);
        }

        public static DateTime ToDateTime(JToken value)
        {
            return value.Value<DateTime>();
        }

        public static DateTime ToDateTime(DateTime? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        [CLSCompliant(false)]
        public static DateTime ToDateTime(sbyte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(byte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(short? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        [CLSCompliant(false)]
        public static DateTime ToDateTime(ushort? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(int? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        [CLSCompliant(false)]
        public static DateTime ToDateTime(uint? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(long? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        [CLSCompliant(false)]
        public static DateTime ToDateTime(ulong? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(bool? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(char? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(float? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(double? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(decimal? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        #endregion ToDateTime

        #region ToDecimal

        [CLSCompliant(false)]
        public static decimal ToDecimal(JValue value)
        {
            return Convert.ToDecimal(value.Value);
        }

        public static Decimal ToDecimal(JToken value)
        {
            return value.Value<Decimal>();
        }

        [CLSCompliant(false)]
        public static decimal ToDecimal(sbyte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(byte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(char? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(short? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static decimal ToDecimal(ushort? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(int? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static decimal ToDecimal(uint? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(long? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static decimal ToDecimal(ulong? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(float? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(double? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(decimal? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(bool? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(DateTime? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        #endregion ToDecimal

        #region ToDouble

        [CLSCompliant(false)]
        public static double ToDouble(JValue value)
        {
            return Convert.ToDouble(value.Value);
        }

        public static Double ToDouble(JToken value)
        {
            return value.Value<Double>();
        }

        [CLSCompliant(false)]
        public static double ToDouble(sbyte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(byte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(short? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(char? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static double ToDouble(ushort? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(int? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static double ToDouble(uint? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(long? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static double ToDouble(ulong? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(float? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(double? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(decimal? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(bool? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(DateTime? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        #endregion ToDouble

        #region ToInt32

        [CLSCompliant(false)]
        public static Int32 ToInt32(JValue value)
        {
            return Convert.ToInt32(value.Value);
        }

        public static Int32 ToInt32(JToken value)
        {
            return value.Value<Int32>();
        }

        public static int ToInt32(bool? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(char? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static int ToInt32(sbyte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(byte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(short? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static int ToInt32(ushort? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static int ToInt32(uint? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(int? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(long? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static int ToInt32(ulong? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(float? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(double? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(decimal? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(DateTime? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        #endregion ToInt32

        #region ToInt64

        [CLSCompliant(false)]
        public static long ToInt64(JValue value)
        {
            return Convert.ToInt64(value.Value);
        }

        public static Int64 ToInt64(JToken value)
        {
            return value.Value<Int64>();
        }

        public static long ToInt64(bool? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(char? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static long ToInt64(sbyte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(byte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(short? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static long ToInt64(ushort? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(int? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static long ToInt64(uint? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static long ToInt64(ulong? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(long? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(float? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(double? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(decimal? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(DateTime? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(bool? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(char? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        #endregion ToInt64

        #region ToByte

        [CLSCompliant(false)]
        public static byte ToByte(JValue value)
        {
            return Convert.ToByte(value.Value);
        }

        public static byte ToByte(JToken value)
        {
            return value.Value<byte>();
        }

        public static byte ToByte(bool? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(char? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        [CLSCompliant(false)]
        public static byte ToByte(sbyte? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(short? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        [CLSCompliant(false)]
        public static byte ToByte(ushort? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(int? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        [CLSCompliant(false)]
        public static byte ToByte(uint? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(long? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        [CLSCompliant(false)]
        public static byte ToByte(ulong? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(float? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(double? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(decimal? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(DateTime? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }
        #endregion ToSByte

        #region ToSingle

        [CLSCompliant(false)]
        public static float ToSingle(JValue value)
        {
            return Convert.ToSingle(value.Value);
        }

        public static float ToSingle(JToken value)
        {
            return value.Value<float>();
        }

        [CLSCompliant(false)]
        public static float ToSingle(sbyte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(byte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(char? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(short? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static float ToSingle(ushort? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(int? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static float ToSingle(uint? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(long? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static float ToSingle(ulong? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(float? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(double? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(decimal? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(bool? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(DateTime? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        #endregion ToSingle

        #region ToString          

        [CLSCompliant(false)]
        public static string ToString(JValue value)
        {
            return Convert.ToString(value.Value);
        }

        public static string ToString(JToken value)
        {
            return value.Value<string>();
        }

        public static string ToString(bool? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(bool? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;

        }

        public static string ToString(char? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(char? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(sbyte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(sbyte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(byte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(byte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(short? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(short? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(ushort? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(ushort? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(int? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(int? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(uint? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(uint? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(long? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(long? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(ulong? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        [CLSCompliant(false)]
        public static string ToString(ulong? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(float? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(float? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(double? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(double? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(decimal? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(decimal? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(DateTime? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(DateTime? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        #endregion ToString

        #region ToUInt16

        [CLSCompliant(false)]
        public static ushort ToUInt16(JValue value)
        {
            return Convert.ToUInt16(value.Value);
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(JToken value)
        {
            return value.Value<ushort>();
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(bool? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(char? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(byte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(short? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(int? value) => value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;

        [CLSCompliant(false)]
        public static ushort ToUInt16(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(uint? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(long? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(float? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(double? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        #endregion ToUInt16

        #region ToUInt32

        [CLSCompliant(false)]
        public static uint ToUInt32(JValue value)
        {
            return Convert.ToUInt32(value.Value);
        }

        public static uint ToUInt32(JToken value)
        {
            return value.Value<uint>();
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(bool? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(char? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(byte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(short? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(int? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(uint? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(long? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(float? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(double? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        #endregion ToUInt32

        #region ToUInt64

        [CLSCompliant(false)]
        public static ulong ToUInt64(JValue value)
        {
            return Convert.ToUInt64(value.Value);
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(JToken value)
        {
            return value.Value<ulong>();
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(byte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(short? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(int? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(uint? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(long? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(float? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(double? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        #endregion ToUInt64
    
    }

}
