﻿namespace Cult.Guard
{
    public sealed class Guard : IGuard
    {
        public static IGuard Against { get; } = new Guard();

        private Guard() { }
    }
}
