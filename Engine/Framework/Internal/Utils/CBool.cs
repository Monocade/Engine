using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class Utils
    {
        public readonly struct Bool
        {
            private readonly byte boolean;

            public Bool(bool value)
            {
                boolean = (byte)(value ? 1 : 0);
            }

            public static implicit operator bool(Bool value) => value.boolean != 0;
            public static implicit operator Bool(bool value) => new Bool(value);
        }
    }
}