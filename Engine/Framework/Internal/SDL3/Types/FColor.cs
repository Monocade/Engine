using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FColor
        {
            public float r;
            public float g;
            public float b;
            public float a;
        }
    }
}