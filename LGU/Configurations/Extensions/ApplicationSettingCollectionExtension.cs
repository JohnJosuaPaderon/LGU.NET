using LGU.Utilities;
using System;
using System.Collections.Generic;

namespace LGU.Configurations.Extensions
{
    public static class ApplicationSettingCollectionExtension
    {
        private static void ValidateGetterArguments(ApplicationSettingCollection applicationSettings, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"Argument '{nameof(key)}' is null or white space.");
            }

            if (applicationSettings.Count <= 0)
            {
                throw new ArgumentException($"Argument '{nameof(applicationSettings)}' has no result.");
            }
        }

        private static TResult GetValueBase<TResult>(ApplicationSettingCollection applicationSettings, string key, Func<object, TResult> converter)
        {
            ValidateGetterArguments(applicationSettings, key);
            return converter(applicationSettings[key].Value);
        }

        private static TResult GetValueBase<TResult>(ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider, Func<object, IFormatProvider, TResult> converter)
        {
            ValidateGetterArguments(applicationSettings, key);
            return converter(applicationSettings[key].Value, formatProvider);
        }

        public static bool GetBoolean(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToBoolean);
        }

        public static bool GetBoolean(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToBoolean);
        }

        public static byte GetByte(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToByte);
        }

        public static byte GetByte(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToByte);
        }

        public static char GetChar(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToChar);
        }

        public static char GetChar(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToDateTime);
        }

        public static DateTime GetDateTime(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToDecimal);
        }

        public static decimal GetDecimal(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToDecimal);
        }

        public static double GetDouble(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToDouble);
        }

        public static double GetDouble(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToDouble);
        }

        public static short GetInt16(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToInt16);
        }

        public static short GetInt16(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToInt16);
        }

        public static int GetInt32(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToInt32);
        }

        public static int GetInt32(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToInt32);
        }

        public static long GetInt64(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToInt64);
        }

        public static long GetInt64(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableBoolean);
        }

        public static bool? GetNullableBoolean(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableByte);
        }

        public static byte? GetNullableByte(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableChar);
        }

        public static char? GetNullableChar(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableDateTime);
        }

        public static DateTime? GetNullableDateTime(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableDecimal);
        }

        public static decimal? GetNullableDecimal(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableDouble);
        }

        public static double? GetNullableDouble(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableInt16);
        }

        public static short? GetNullableInt16(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableInt32);
        }

        public static int? GetNullableInt32(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableInt32);
        }

        public static long? GetNullableInt64(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableInt64);
        }

        public static long? GetNullableInt64(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableSByte);
        }

        public static sbyte? GetNullableSByte(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableSingle);
        }

        public static float? GetNullableSingle(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableSingle);
        }

        public static ushort? GetNullableUInt16(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableUInt16);
        }

        public static ushort? GetNullableUInt16(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableUInt32);
        }

        public static uint? GetNullableUInt32(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableUInt64);
        }

        public static ulong? GetNullableUInt64(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToSByte);
        }

        public static sbyte GetSByte(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToSByte);
        }

        public static float GetSingle(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToSingle);
        }

        public static float GetSingle(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToSingle);
        }

        public static string GetString(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToString);
        }

        public static string GetString(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToString);
        }

        public static ushort GetUInt16(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToUInt16);
        }

        public static ushort GetUInt16(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToUInt32);
        }

        public static uint GetUInt32(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToUInt64);
        }

        public static ulong GetUInt64(this ApplicationSettingCollection applicationSettings, string key, IFormatProvider formatProvider)
        {
            return GetValueBase(applicationSettings, key, formatProvider, ValueConverter.ToUInt64);
        }

        public static byte[] GetByteArray(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToByteArray);
        }

        public static TimeSpan GetTimeSpan(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToTimeSpan);
        }

        public static TimeSpan? GetNullableTimeSpan(this ApplicationSettingCollection applicationSettings, string key)
        {
            return GetValueBase(applicationSettings, key, ValueConverter.ToNullableTimeSpan);
        }

        public static Dictionary<string, object> ToDictionary(this ApplicationSettingCollection applicationSettings)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (var applicationSetting in applicationSettings)
            {
                dictionary.Add(applicationSetting.Key, applicationSetting.Value);
            }

            return dictionary;
        }
    }
}
