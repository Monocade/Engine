using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class BOX2D
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Version
        {
            public int major;
            public int minor;
            public int revision;
        }
    }
}