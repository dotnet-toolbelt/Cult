﻿// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable UnusedMember.Global
namespace Cult.DotLiquid.Filters
{
    public static class DotLiquidCustomFilters
    {
        public static string IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input) ? "true" : "false";
        }
    }
}
