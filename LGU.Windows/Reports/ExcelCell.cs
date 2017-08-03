using Newtonsoft.Json.Linq;
using System;
using LGU.Extensions;

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
            return arg != null ? FromJson(arg) : new ExcelCell();
        }

        public static explicit operator ExcelCell(JObject arg)
        {
            return arg != null ? FromJson(arg) : new ExcelCell();
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
    }
}
