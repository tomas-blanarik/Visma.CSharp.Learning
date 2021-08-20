﻿using System;

namespace Session5
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());

        private Singleton() { }

        public static Singleton Instance { get { return _lazy.Value; } }

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
