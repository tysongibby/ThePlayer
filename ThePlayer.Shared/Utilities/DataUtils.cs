﻿using ThePlayer.Shared.Settings;
using ThePlayer.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer.Shared.Utilities
{
    public sealed class DataUtils
    {
        private static string EscapeQuotes(string source)
        {
            return source.Replace("'", "''");
        }

        public static string CreateInClause(string columnName, IList<string> clauseItems)
        {
            string commaSeparatedItems = string.Join(",", clauseItems.Select((item) => "'" + EscapeQuotes(item) + "'").ToArray());

            return $"{columnName} IN ({commaSeparatedItems})";
        }

        public static string CreateOrLikeClause(string columnName, IList<string> clauseItems, string delimiter = "")
        {
            var sb = new StringBuilder();

            sb.AppendLine("(");

            var orClauses = new List<string>();

            foreach (string clauseItem in clauseItems)
            {
                if (string.IsNullOrEmpty(clauseItem))
                {
                    orClauses.Add($@"({columnName} IS NULL OR {columnName}='')");
                }
                else
                {
                    orClauses.Add($@"(LOWER({columnName}) LIKE LOWER('%{delimiter}{clauseItem.Replace("'", "''")}{delimiter}%'))");
                }
            }

            sb.AppendLine(string.Join(" OR ", orClauses.ToArray()));
            sb.AppendLine(")");

            return sb.ToString();
        }

        public static IEnumerable<string> SplitColumnMultiValue(string columnMultiValue)
        {
            return columnMultiValue.Split(Constants.DoubleColumnValueDelimiter);
        }

        public static string TrimColumnValue(string columnValue)
        {
            return columnValue.Trim(Constants.ColumnValueDelimiter);
        }

        public static IEnumerable<string> SplitAndTrimColumnMultiValue(string columnMultiValue)
        {
            return SplitColumnMultiValue(columnMultiValue).Select(x => TrimColumnValue(x));
        }

        public static string GetCommaSeparatedColumnMultiValue(string columnMultiValue)
        {
            if (columnMultiValue.Contains(Constants.DoubleColumnValueDelimiter))
            {
                return string.Join(", ", SplitAndTrimColumnMultiValue(columnMultiValue));
            }

            return TrimColumnValue(columnMultiValue);
        } 
    }
}
