using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }
    }
}