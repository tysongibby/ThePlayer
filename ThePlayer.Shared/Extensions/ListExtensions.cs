﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ThePlayer.Shared.Extensions
{
    public static class ListExtensions
    {
        public static string FirstNonEmpty(this IEnumerable<string> strings, string alternateString)
        {
            foreach (string item in strings)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    return item;
                }
            }

            return alternateString;
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static List<T> Randomize<T>(this List<T> list)
        {
            var originalList = new List<T>(list); // Create a new list, so no operation performed here affects the original list object.
            var randomList = new List<T>();

            var r = new Random();

            int randomIndex = 0;

            while (originalList.Count > 0)
            {
                randomIndex = r.Next(0, originalList.Count);  // Choose a random object in the list
                randomList.Add(originalList[randomIndex]); // Add it to the new, random list
                originalList.RemoveAt(randomIndex); // Remove to avoid duplicates
            }

            return randomList;
        }

        public static IEnumerable<string> SortNaturally(this IEnumerable<string> strings)
        {
            return strings.OrderBy(x => Regex.Replace(x, @"\d+", match => match.Value.PadLeft(4, '0')));
        }
    }
}
