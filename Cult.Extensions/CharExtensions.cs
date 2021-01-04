using System;
using System.Globalization;

// ReSharper disable UnusedMember.Global

namespace Cult.Extensions
{
    public static class CharExtensions
    {
        public static double GetNumericValue(this char c)
        {
            return char.GetNumericValue(c);
        }

        public static UnicodeCategory GetUnicodeCategory(this char c)
        {
            return char.GetUnicodeCategory(c);
        }

        public static bool In(this char @this, params char[] values)
        {
            return Array.IndexOf(values, @this) != -1;
        }

        public static bool IsControl(this char c)
        {
            return char.IsControl(c);
        }

        public static bool IsDigit(this char c)
        {
            return char.IsDigit(c);
        }

        public static bool IsHighSurrogate(this char c)
        {
            return char.IsHighSurrogate(c);
        }

        public static bool IsLetter(this char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsLetterOrDigit(this char c)
        {
            return char.IsLetterOrDigit(c);
        }

        public static bool IsLower(this char c)
        {
            return char.IsLower(c);
        }

        public static bool IsLowSurrogate(this char c)
        {
            return char.IsLowSurrogate(c);
        }

        public static bool IsNumber(this char c)
        {
            return char.IsNumber(c);
        }

        public static bool IsPunctuation(this char c)
        {
            return char.IsPunctuation(c);
        }

        public static bool IsSeparator(this char c)
        {
            return char.IsSeparator(c);
        }

        public static bool IsSurrogate(this char c)
        {
            return char.IsSurrogate(c);
        }

        public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate)
        {
            return char.IsSurrogatePair(highSurrogate, lowSurrogate);
        }

        public static bool IsSymbol(this char c)
        {
            return char.IsSymbol(c);
        }

        public static bool IsUpper(this char c)
        {
            return char.IsUpper(c);
        }

        public static bool IsWhiteSpace(this char c)
        {
            return char.IsWhiteSpace(c);
        }
        public static bool NotIn(this char @this, params char[] values)
        {
            return Array.IndexOf(values, @this) == -1;
        }

        public static string Repeat(this char @this, int repeatCount)
        {
            return new string(@this, repeatCount);
        }
        public static char ToLower(this char c, CultureInfo culture)
        {
            return char.ToLower(c, culture);
        }
        public static char ToLower(this char c)
        {
            return char.ToLower(c);
        }

        public static char ToLowerInvariant(this char c)
        {
            return char.ToLowerInvariant(c);
        }
        public static string ToUnicodeString(this char c)
        {
            return $@"\u{(int)c:x4}";
        }
        public static char ToUpper(this char c, CultureInfo culture)
        {
            return char.ToUpper(c, culture);
        }

        public static char ToUpper(this char c)
        {
            return char.ToUpper(c);
        }

        public static char ToUpperInvariant(this char c)
        {
            return char.ToUpperInvariant(c);
        }
        public static bool Is(this char c, Predicate<char> predicate)
        {
            return predicate(c);
        }
    }
}