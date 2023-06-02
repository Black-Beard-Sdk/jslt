using System;

namespace Bb.Expressions
{
    public static partial class CustomConverter
    {

        #region? ToBoolean

        public static bool? ToBoolean(bool value)
        {
            return new bool?(value);
        }

        [CLSCompliant(false)]
        public static bool? ToBoolean(sbyte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(char value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(byte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(short value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        [CLSCompliant(false)]
        public static bool? ToBoolean(ushort value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(int value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        [CLSCompliant(false)]
        public static bool? ToBoolean(uint value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(long value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        [CLSCompliant(false)]
        public static bool? ToBoolean(ulong value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(float value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(double value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(decimal value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(DateTime value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        #endregion? ToBoolean

        #region ToByte               

        [CLSCompliant(false)]
        public static sbyte? ToSByte(bool value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(sbyte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(char value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(byte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(short value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(ushort value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(int value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(uint value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(long value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(ulong value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(float value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(double value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(decimal value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        [CLSCompliant(false)]
        public static sbyte? ToSByte(DateTime value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        #endregion ToByte

        #region ToChar

        public static char? ToChar(bool value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(char value)
        {
            return new char?(Convert.ToChar(value));
        }

        [CLSCompliant(false)]
        public static char? ToChar(sbyte value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(byte value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(short value)
        {
            return new char?(Convert.ToChar(value));
        }

        [CLSCompliant(false)]
        public static char? ToChar(ushort value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(int value) => ToChar((uint)value);

        [CLSCompliant(false)]
        public static char? ToChar(uint value)
        {
            return new char?(Convert.ToChar(value));
        }

        [CLSCompliant(false)]
        public static char? ToChar(ulong value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(float value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(double value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(decimal value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(DateTime value)
        {
            return new char?(Convert.ToChar(value));
        }

        #endregion ToChar

        #region ToInt16

        public static short? ToInt16(bool value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(char value)
        {
            return new short?(Convert.ToInt16(value));
        }

        [CLSCompliant(false)]
        public static short? ToInt16(sbyte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(byte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        [CLSCompliant(false)]
        public static short? ToInt16(ushort value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(int value)
        {
            return new short?(Convert.ToInt16(value));
        }

        [CLSCompliant(false)]
        public static short? ToInt16(uint value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(short value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(long value)
        {
            return new short?(Convert.ToInt16(value));
        }

        [CLSCompliant(false)]
        public static short? ToInt16(ulong value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(float value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(double value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(decimal value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(DateTime value)
        {
            return new short?(Convert.ToInt16(value));
        }

        #endregion ToInt16        

        #region ToDateTime

        public static DateTime? ToDateTime(DateTime value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        [CLSCompliant(false)]
        public static DateTime? ToDateTime(sbyte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(byte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(short value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        [CLSCompliant(false)]
        public static DateTime? ToDateTime(ushort value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(int value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        [CLSCompliant(false)]
        public static DateTime? ToDateTime(uint value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(long value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        [CLSCompliant(false)]
        public static DateTime? ToDateTime(ulong value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(bool value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(char value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(float value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(double value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(decimal value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        #endregion ToDateTime

        #region ToDecimal

        [CLSCompliant(false)]
        public static decimal? ToDecimal(sbyte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(byte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(char value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(short value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        [CLSCompliant(false)]
        public static decimal? ToDecimal(ushort value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(int value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        [CLSCompliant(false)]
        public static decimal? ToDecimal(uint value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(long value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        [CLSCompliant(false)]
        public static decimal? ToDecimal(ulong value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(float value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(double value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(decimal value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(bool value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(DateTime value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        #endregion ToDecimal

        #region ToDouble

        [CLSCompliant(false)]
        public static double? ToDouble(sbyte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(byte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(short value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(char value)
        {
            return new double?(Convert.ToDouble(value));
        }

        [CLSCompliant(false)]
        public static double? ToDouble(ushort value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(int value)
        {
            return new double?(Convert.ToDouble(value));
        }

        [CLSCompliant(false)]
        public static double? ToDouble(uint value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(long value)
        {
            return new double?(Convert.ToDouble(value));
        }

        [CLSCompliant(false)]
        public static double? ToDouble(ulong value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(float value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(double value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(decimal value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(bool value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(DateTime value)
        {
            return new double?(Convert.ToDouble(value));
        }

        #endregion ToDouble

        #region ToInt32

        public static int? ToInt32(bool value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(char value)
        {
            return new int?(Convert.ToInt32(value));
        }

        [CLSCompliant(false)]
        public static int? ToInt32(sbyte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(byte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(short value)
        {
            return new int?(Convert.ToInt32(value));
        }

        [CLSCompliant(false)]
        public static int? ToInt32(ushort value)
        {
            return new int?(Convert.ToInt32(value));
        }

        [CLSCompliant(false)]
        public static int? ToInt32(uint value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(int value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(long value)
        {
            return new int?(Convert.ToInt32(value));
        }

        [CLSCompliant(false)]
        public static int? ToInt32(ulong value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(float value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(double value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(decimal value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(DateTime value)
        {
            return new int?(Convert.ToInt32(value));
        }

        #endregion ToInt32

        #region ToInt64

        public static long? ToInt64(bool value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(char value)
        {
            return new long?(Convert.ToInt64(value));
        }

        [CLSCompliant(false)]
        public static long? ToInt64(sbyte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(byte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(short value)
        {
            return new long?(Convert.ToInt64(value));
        }

        [CLSCompliant(false)]
        public static long? ToInt64(ushort value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(int value)
        {
            return new long?(Convert.ToInt64(value));
        }

        [CLSCompliant(false)]
        public static long? ToInt64(uint value)
        {
            return new long?(Convert.ToInt64(value));
        }

        [CLSCompliant(false)]
        public static long? ToInt64(ulong value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(long value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(float value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(double value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(decimal value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(DateTime value)
        {
            return new long?(Convert.ToInt64(value));
        }

        #endregion ToInt64

        #region ToByte

        public static byte? ToByte(bool value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(char value)
        {
            return new byte?(Convert.ToByte(value));
        }

        [CLSCompliant(false)]
        public static byte? ToByte(sbyte value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(short value)
        {
            return new byte?(Convert.ToByte(value));
        }

        [CLSCompliant(false)]
        public static byte? ToByte(ushort value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(int value) => ToByte((uint)value);

        [CLSCompliant(false)]
        public static byte? ToByte(uint value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(long value) => ToByte((ulong)value);

        [CLSCompliant(false)]
        public static byte? ToByte(ulong value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(float value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(double value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(decimal value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(DateTime value)
        {
            return new byte?(Convert.ToByte(value));
        }
        #endregion ToSByte

        #region ToSingle

        [CLSCompliant(false)]
        public static float? ToSingle(sbyte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(byte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(char value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(short value)
        {
            return new float?(Convert.ToSingle(value));
        }

        [CLSCompliant(false)]
        public static float? ToSingle(ushort value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(int value)
        {
            return new float?(Convert.ToSingle(value));
        }

        [CLSCompliant(false)]
        public static float? ToSingle(uint value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(long value)
        {
            return new float?(Convert.ToSingle(value));
        }

        [CLSCompliant(false)]
        public static float? ToSingle(ulong value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(float value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(double value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(decimal value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(bool value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(DateTime value)
        {
            return new float?(Convert.ToSingle(value));
        }

        #endregion ToSingle

        #region ToUInt16

        [CLSCompliant(false)]
        public static ushort? ToUInt16(bool value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(char value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(sbyte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(byte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(short value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(int value) => ToUInt16((uint)value);

        [CLSCompliant(false)]
        public static ushort? ToUInt16(ushort value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(uint value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(long value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(ulong value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(float value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(double value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(decimal value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        [CLSCompliant(false)]
        public static ushort? ToUInt16(DateTime value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        #endregion ToUInt16

        #region ToUInt32

        [CLSCompliant(false)]
        public static uint? ToUInt32(bool value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(char value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(sbyte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(byte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(short value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(ushort value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(int value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(uint value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(long value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(ulong value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(float value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(double value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(decimal value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        [CLSCompliant(false)]
        public static uint? ToUInt32(DateTime value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        #endregion ToUInt32

        #region ToUInt64

        [CLSCompliant(false)]
        public static ulong? ToUInt64(bool value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(char value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }
        [CLSCompliant(false)]
        public static ulong? ToUInt64(sbyte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(byte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(short value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(ushort value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(int value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(uint value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(long value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(ulong value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(float value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(double value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(decimal value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        [CLSCompliant(false)]
        public static ulong? ToUInt64(DateTime value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        #endregion ToUInt64

    }

}
