using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FRect
        {
            public float x;
            public float y;
            public float w;
            public float h;
        }
    }
}