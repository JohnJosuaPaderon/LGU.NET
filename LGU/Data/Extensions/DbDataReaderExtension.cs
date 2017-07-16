using LGU.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace LGU.Data.Extensions
{
    public static class DbDataReaderExtension
    {
        private static void ValidateGetterArguments(DbDataReader reader, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException($"Argument '{nameof(fieldName)}' is null or white space.");
            }

            if (reader.FieldCount <= 0)
            {
                throw new ArgumentException($"Argument '{nameof(reader)}' has no result.");
            }
        }

        private static TResult GetValueBase<TResult>(DbDataReader reader, string fieldName, Func<object, TResult> converter)
        {
            ValidateGetterArguments(reader, fieldName);
            return converter(reader[fieldName]);
        }

        private static TResult GetValueBase<TResult>(DbDataReader reader, string fieldName, IFormatProvider formatProvider, Func<object, IFormatProvider, TResult> converter)
        {
            ValidateGetterArguments(reader, fieldName);
            return converter(reader[fieldName], formatProvider);
        }

        public static bool GetBoolean(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToBoolean);
        }

        public static bool GetBoolean(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToBoolean);
        }

        public static byte GetByte(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToByte);
        }

        public static byte GetByte(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToByte);
        }

        public static char GetChar(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToChar);
        }

        public static char GetChar(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToDateTime);
        }

        public static DateTime GetDateTime(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToDecimal);
        }

        public static decimal GetDecimal(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToDecimal);
        }

        public static double GetDouble(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToDouble);
        }

        public static double GetDouble(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToDouble);
        }

        public static short GetInt16(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToInt16);
        }

        public static short GetInt16(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToInt16);
        }

        public static int GetInt32(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToInt32);
        }

        public static int GetInt32(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToInt32);
        }

        public static long GetInt64(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToInt64);
        }

        public static long GetInt64(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableBoolean);
        }

        public static bool? GetNullableBoolean(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableByte);
        }

        public static byte? GetNullableByte(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableChar);
        }

        public static char? GetNullableChar(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableDateTime);
        }

        public static DateTime? GetNullableDateTime(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableDecimal);
        }

        public static decimal? GetNullableDecimal(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableDouble);
        }

        public static double? GetNullableDouble(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableInt16);
        }

        public static short? GetNullableInt16(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableInt32);
        }

        public static int? GetNullableInt32(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableInt32);
        }

        public static long? GetNullableInt64(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableInt64);
        }

        public static long? GetNullableInt64(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableSByte);
        }

        public static sbyte? GetNullableSByte(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableSingle);
        }

        public static float? GetNullableSingle(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableSingle);
        }

        public static ushort? GetNullableUInt16(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableUInt16);
        }

        public static ushort? GetNullableUInt16(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableUInt32);
        }

        public static uint? GetNullableUInt32(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableUInt64);
        }

        public static ulong? GetNullableUInt64(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToSByte);
        }

        public static sbyte GetSByte(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToSByte);
        }

        public static float GetSingle(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToSingle);
        }

        public static float GetSingle(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToSingle);
        }

        public static string GetString(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToString);
        }

        public static string GetString(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToString);
        }

        public static ushort GetUInt16(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToUInt16);
        }

        public static ushort GetUInt16(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToUInt32);
        }

        public static uint GetUInt32(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToUInt64);
        }

        public static ulong GetUInt64(this DbDataReader reader, string fieldName, IFormatProvider formatProvider)
        {
            return GetValueBase(reader, fieldName, formatProvider, DbValueConverter.ToUInt64);
        }

        public static Stream GetStream(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToStream);
        }

        public static TimeSpan GetTimeSpan(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToTimeSpan);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbDataReader reader, string fieldName)
        {
            return GetValueBase(reader, fieldName, DbValueConverter.ToNullableTimeSpan);
        }

        public static Dictionary<string, object> ToDictionary(this DbDataReader reader)
        {
            var dictionary = new Dictionary<string, object>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dictionary.Add(reader.GetName(i), reader.GetValue(i));
            }
            return dictionary;
        }
    }
}
