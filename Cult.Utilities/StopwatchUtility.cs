﻿using System;
using System.Diagnostics;
namespace Cult.Utilities
{
    public static class StopwatchUtility
    {
        public static TimeSpan GetExecutionTime(Action action)
        {
            var start = new Stopwatch();
            start.Start();
            action();
            start.Stop();
            return start.Elapsed;
        }
    }
}
