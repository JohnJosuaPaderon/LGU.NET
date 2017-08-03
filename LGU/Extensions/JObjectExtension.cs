using LGU.Utilities;
using Newtonsoft.Json.Linq;
using System;

namespace LGU.Extensions
{
    public static class JObjectExtension
    {
        private static void Validate(JObject jObject, string propertyName)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException(nameof(jObject));
            }

            if (jObject.Count <= 0)
            {
                throw new ArgumentException(nameof(jObject), "JObject has no children.");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException(nameof(propertyName), "Property name is invalid.");
            }
        }

        private static T GetValueBase<T>(JObject jObject, string propertyName, Func<object, T> converter)
        {
            Validate(jObject, propertyName);
            return converter(jObject[propertyName]);
        }

        public static bool GetBoolean(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToBoolean);
        }

        public static byte GetByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToByte);
        }

        public static char GetChar(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToDecimal);
        }

        public static double GetDouble(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToDouble);
        }

        public static short GetInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToInt16);
        }

        public static int GetInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToInt32);
        }

        public static long GetInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableInt16);
        }

        public static long? GetNullableInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableSingle);
        }

        public static TimeSpan? GetNullableTimeSpan(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableTimeSpan);
        }

        public static ushort? GetNullableUInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToSByte);
        }

        public static float GetSingle(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToSingle);
        }

        public static string GetString(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToString);
        }

        public static TimeSpan GetTimeSpan(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToTimeSpan);
        }

        public static ushort GetUInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, ValueConverter.ToUInt64);
        }
    }
}
