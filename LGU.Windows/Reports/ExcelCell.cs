using LGU.Extensions;
using Newtonsoft.Json.Linq;
using System;

namespace LGU.Reports
{
    public struct ExcelCell
    {
        public ExcelCell(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public static explicit operator ExcelCell(JToken arg)
        {
            return FromJson(arg);
        }

        public static explicit operator ExcelCell(JObject arg)
        {
            return FromJson(arg);
        }

        public static explicit operator ExcelCell(string arg)
        {
            return FromString(arg);
        }

        public static ExcelCell FromJson(JToken jSource)
        {
            if (jSource is JObject jObject)
            {
                return FromJson(jObject);
            }
            else
            {
                return new ExcelCell();
            }
        }

        public static ExcelCell FromJson(JObject jSource)
        {
            if (jSource == null)
            {
                throw new ArgumentNullException(nameof(jSource));
            }
            else
            {
                return new ExcelCell(jSource.GetInt32("RowIndex"), jSource.GetInt32("ColumnIndex"));
            }
        }

        public static ExcelCell FromString(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("String source of excel cell is invalid.", nameof(source));
            }
            else if (!source.Contains(","))
            {
                throw new ArgumentException("String source of excel cell is invalid.", nameof(source));
            }
            else
            {
                var splitted = source.Split(',');

                if (splitted.Length == 2)
                {
                    if (int.TryParse(splitted[0], out int row) && int.TryParse(splitted[1], out int column))
                    {
                        return new ExcelCell(row, column);
                    }
                    else
                    {
                        throw new ArgumentException("Failed to parse string source of excel cell.");
                    }
                }
                else
                {
                    throw new ArgumentException("String source of excel cell is invalid.", nameof(source));
                }
            }
        }
    }
}
