using System;

namespace Project.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveQuotes(this string Value)
        {
            return Value.Replace("\"", "");
        }
    }
}
