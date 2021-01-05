﻿using System.Collections.Generic;
using System.Linq;
namespace Cult.Persian
{
    public enum DigitGroup
    {
        Ones,

        Teens,

        Tens,

        Hundreds,

        Thousands
    }
    public enum Language
    {
        English,

        Persian
    }
    public static class HumanReadableInteger
    {
        internal static readonly IDictionary<Language, string> _and = new Dictionary<Language, string>
        {
            { Language.English, " " },
            { Language.Persian, " و " }
        };
        internal static readonly IList<NumberWord> _numberWords = new List<NumberWord>
        {
            new NumberWord { Group= DigitGroup.Ones, Language= Language.English, Names=
                new List<string> { string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }},
            new NumberWord { Group= DigitGroup.Ones, Language= Language.Persian, Names=
                new List<string> { string.Empty, "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" }},

            new NumberWord { Group= DigitGroup.Teens, Language= Language.English, Names=
                new List<string> { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }},
            new NumberWord { Group= DigitGroup.Teens, Language= Language.Persian, Names=
                new List<string> { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" }},

            new NumberWord { Group= DigitGroup.Tens, Language= Language.English, Names=
                new List<string> { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }},
            new NumberWord { Group= DigitGroup.Tens, Language= Language.Persian, Names=
                new List<string> { "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" }},

            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.English, Names=
                new List<string> {string.Empty, "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred",
                    "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred" }},
            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Persian, Names=
                new List<string> {string.Empty, "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد" , "نهصد" }},

            new NumberWord { Group= DigitGroup.Thousands, Language= Language.English, Names=
              new List<string> { string.Empty, " Thousand", " Million", " Billion"," Trillion", " Quadrillion", " Quintillion", " Sextillian",
            " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
            " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
            " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
            " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
            new NumberWord { Group= DigitGroup.Thousands, Language= Language.Persian, Names=
              new List<string> {
                string.Empty,
                " هزار",
                " میلیون",
                " میلیارد",
                " تریلیون",
                " کادریلیون",
                " کوينتيليون",
                " سکستيليون",
                " سپتيليون",
                " اکتيليون",
                " نونيليون",
                " دسيليون",
                " آندسيليون",
                " دودسيليون",
                " تريدسيليون",
                " کواتردسيليون",
                " کويندسيليون",
                " سيکسدسيليون",
                " سپتندسيليون",
                " اکتودسيليوم",
                " نومدسيليون",
                " ويجينتيليون",
                " آنويجينتيليون",
                " دويجينتيليون",
                " 10^72",
                " 10^75",
                " 10^78",
                " 10^81",
                " 10^84",
                " 10^87",
                " Vigintinonillion",
                " 10^93",
                " 10^96",
                " Duotrigintillion",
                " Trestrigintillion"
                }
            },
        };
        internal static readonly IDictionary<Language, string> _negative = new Dictionary<Language, string>
        {
            { Language.English, "Negative " },
            { Language.Persian, "منهای " }
        };
        internal static readonly IDictionary<Language, string> _zero = new Dictionary<Language, string>
        {
            { Language.English, "Zero" },
            { Language.Persian, "صفر" }
        };
        internal static string getName(int idx, Language language, DigitGroup group)
        {
            return _numberWords.First(x => x.Group == group && x.Language == language).Names.ElementAt(idx);
        }
        public static string NumberToText(this int number, Language language)
        {
            return NumberToText((long)number, language);
        }
        public static string NumberToText(this uint number, Language language)
        {
            return NumberToText((long)number, language);
        }
        public static string NumberToText(this byte number, Language language)
        {
            return NumberToText((long)number, language);
        }
        public static string NumberToText(this decimal number, Language language)
        {
            return NumberToText((long)number, language);
        }
        public static string NumberToText(this double number, Language language)
        {
            return NumberToText((long)number, language);
        }
        public static string NumberToText(this long number, Language language)
        {
            if (number == 0)
            {
                return _zero[language];
            }

            if (number < 0)
            {
                return _negative[language] + NumberToText(-number, language);
            }

            return wordify(number, language, string.Empty, 0);
        }
        internal static string wordify(long number, Language language, string leftDigitsText, int thousands)
        {
            if (number == 0)
            {
                return leftDigitsText;
            }

            var wordValue = leftDigitsText;
            if (wordValue.Length > 0)
            {
                wordValue += _and[language];
            }

            if (number < 10)
            {
                wordValue += getName((int)number, language, DigitGroup.Ones);
            }
            else if (number < 20)
            {
                wordValue += getName((int)(number - 10), language, DigitGroup.Teens);
            }
            else if (number < 100)
            {
                wordValue += wordify(number % 10, language, getName((int)(number / 10 - 2), language, DigitGroup.Tens), 0);
            }
            else if (number < 1000)
            {
                wordValue += wordify(number % 100, language, getName((int)(number / 100), language, DigitGroup.Hundreds), 0);
            }
            else
            {
                wordValue += wordify(number % 1000, language, wordify(number / 1000, language, string.Empty, thousands + 1), 0);
            }

            if (number % 1000 == 0) return wordValue;
            return wordValue + getName(thousands, language, DigitGroup.Thousands);
        }
    }
    public class NumberWord
    {
        public DigitGroup Group { set; get; }
        public Language Language { set; get; }
        public IEnumerable<string> Names { get; set; } = new List<string>();
    }
}
