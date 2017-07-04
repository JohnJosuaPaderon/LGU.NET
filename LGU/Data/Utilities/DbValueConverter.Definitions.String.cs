﻿using LGU.Utilities;
using System;

namespace LGU.Data.Utilities
{
    partial class DbValueConverter
    {
        public static string ToString(bool value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(bool value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(byte value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(byte value, int toBase)
        {
            return ConversionBase(value, toBase, ValueConverter.ToString);
        }

        public static string ToString(byte value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(char value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(char value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(DateTime value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(DateTime value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(decimal value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(decimal value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(double value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(double value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(short value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(short value, int toBase)
        {
            return ConversionBase(value, toBase, ValueConverter.ToString);
        }

        public static string ToString(short value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(int value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(int value, int toBase)
        {
            return ConversionBase(value, toBase, ValueConverter.ToString);
        }

        public static string ToString(int value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(long value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(long value, int toBase)
        {
            return ConversionBase(value, toBase, ValueConverter.ToString);
        }

        public static string ToString(long value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(object value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(sbyte value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(sbyte value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(float value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(float value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(string value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(string value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(ushort value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(ushort value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(uint value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(uint value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }

        public static string ToString(ulong value)
        {
            return ConversionBase(value, ValueConverter.ToString);
        }

        public static string ToString(ulong value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToString);
        }
    }
}
