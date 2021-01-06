﻿// ReSharper disable All 
namespace Cult.SimMetrics.Api
{
    internal interface IAffineGapCost
    {
        double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap);

        double MaxCost { get; }

        double MinCost { get; }

        string ShortDescriptionString { get; }
    }
}

